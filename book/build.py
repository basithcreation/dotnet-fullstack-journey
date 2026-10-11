"""Build the interactive book page from the Markdown chapters.

Usage:  python book/build.py
Reads   book/README.md (phase names), book/phase-XX/NN-*.md (chapters), book/journey.json (daily log)
Writes  book/site/index.html (from book/site/template.html)
"""
import json
import re
from pathlib import Path

BOOK = Path(__file__).resolve().parent
TEMPLATE = BOOK / "site" / "template.html"
OUTPUT = BOOK / "site" / "index.html"

# Phase names come from the README table of contents: "### Phase 1: C# Bricks (...)"
phases = {}
for line in (BOOK / "README.md").read_text(encoding="utf-8").splitlines():
    m = re.match(r"### Phase (\d+): ([^(]+)", line)
    if m:
        phases[int(m.group(1))] = m.group(2).strip()

chapters = []
for path in sorted(BOOK.glob("phase-*/*.md")):
    phase = int(path.parent.name.split("-")[1])
    number = int(path.name.split("-")[0])
    md = path.read_text(encoding="utf-8")
    title = re.search(r"^# (.+)$", md, re.M).group(1)
    chapters.append({
        "id": f"{phase}.{number}",
        "phase": phase,
        "phaseName": phases.get(phase, ""),
        "file": f"{path.parent.name}/{path.name}",
        "title": re.sub(r"^Chapter [\d.]+: ", "", title),
        "md": md,
    })

journey = json.loads((BOOK / "journey.json").read_text(encoding="utf-8"))

def as_js(value):
    # "</" would end the <script> tag early
    return json.dumps(value, ensure_ascii=False).replace("</", "<\\/")

html = TEMPLATE.read_text(encoding="utf-8")
html = html.replace("/*__CHAPTERS__*/[]", as_js(chapters))
html = html.replace("/*__JOURNEY__*/{}", as_js(journey))
OUTPUT.write_text(html, encoding="utf-8")
print(f"Built {OUTPUT.relative_to(BOOK.parent)}: {len(chapters)} chapters, {len(journey['days'])} days")
