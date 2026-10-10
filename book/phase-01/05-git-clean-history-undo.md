# Chapter 1.5: Git, clean history and undo

> Learned: Sat 10 Oct 2026 · Builds on [Chapter 0.2](../phase-00/02-git-basics.md)

---

## 🧸 LKG story

Remember the **photo album**: desk (your files) → box (staged) → photo (commit) → cloud (GitHub).

Today's new skills:
- **Look before you shoot:** check what's on the desk and in the box before you take the photo.
- **Good captions:** a caption should tell anyone what's in the photo.
- **Undo:**
  - Scribbled on a page? **Swap it** for the page from the last photo (`git restore`).
  - Put the wrong page in the box? **Take it out** (`git restore --staged`).
  - Last photo was bad and **nobody has seen it yet**? **Retake it** (`git commit --amend`).
  - Bad photo already **shared with friends**? You can't tear it out of their albums, so you add a **new photo that undoes it** (`git revert`).

🎬 **Animation idea:** four short scenes, one per undo tool. For `revert`, show the album growing: photo 5 "Add bad file", then photo 6 "Revert: Add bad file", with the bad file vanishing from the desk while both photos stay in the album.

---

## 💻 Real explanation

### 1. Look before you commit

| Command | Shows |
|---|---|
| `git status` | **which** files changed. Red = not staged, green = staged, **untracked** = new files Git has never seen |
| `git diff` | **what** changed inside files, line by line. `-` red = removed, `+` green = added |
| `git diff <file>` | the same, for one file |
| `git log --oneline` | the history, one line per commit |
| `git log --oneline -3` | only the last 3 commits |
| `git show --stat HEAD` | which files are in the **last** commit |

- `git diff` doesn't show untracked files: there's no old version to compare with.
- A changed line shows as the **whole old line removed** + the **whole new line added**.
- **HEAD** = the commit you're on now (the latest photo).
- If you see `:` or `~` at the bottom, you're in the **pager**. Press **q** to quit.

### 2. Good commit messages

**Rules:**
1. Start with a **verb**, in **present tense**: `Add`, `Fix`, `Update`, `Remove`, `Rename`
2. Say **what** changed, not when ("Day 3" doesn't help anyone)
3. Short: about 50 characters, starting with a capital letter
4. One topic per commit: **atomic commits**

**The test:** the message should finish the sentence *"If applied, this commit will ___"*.
✅ *"If applied, this commit will* **Add switch lessons and grade calculator exercise***"*

| Verb | When | Example |
|---|---|---|
| Add | something new | `Add login page` |
| Fix | a bug | `Fix crash when marks is 65` |
| Update | changed something existing | `Update README with run steps` |
| Remove | deleted something | `Remove unused test lines` |
| Rename | changed a name | `Rename isKuwaiti to residentAnswer` |

| ❌ Bad | ✅ Good |
|---|---|
| `Day:3 if/else, parking meter v2` | `Add parking meter v2 with guards and cap` |
| `Updated Roadmap switch class is finish so the check box is ticked` | `Update roadmap: switch done` |
| `fixed stuff` | `Fix missing return in grade guard` |

Always put the message in **quotes**: `git commit -m "Add switch lessons"`. Without quotes, Git may open the **Vim** editor. To escape Vim and cancel: press **Esc**, type **`:cq`**, press **Enter**.

### 3. The four undo tools

| Situation | Command | Your edits |
|---|---|---|
| I messed up my edits, throw them away | `git restore <file>` | **deleted** ⚠️ (no Ctrl+Z!) |
| I staged the wrong file | `git restore --staged <file>` | **kept**, just unstaged ✅ |
| My last commit is wrong and **not pushed** | `git commit --amend -m "new message"` | replaces the last commit |
| ...and I only forgot a file | `git add <file>` then `git commit --amend --no-edit` | keeps the message |
| A commit is wrong and **already pushed** | `git revert <commit-id> --no-edit` | adds a **new** commit that undoes it |

**Amend makes a new commit ID** every time (`0436b38` → `b85ff63` → `717580a`). It throws the old photo away and makes a new one. That's why:

> ⚠️ **Golden rule: never amend a commit you have already pushed.** Your teammates have the old ID, and their history won't match yours. Use `revert` instead.

**Revert in action:**
```
64f8e6f Revert "Add git practice file"   ← new commit that undoes it
2ebab8f Add git practice file            ← the bad commit is still in history
```
Nothing is erased. The history tells the honest story: "I did X, then I undid X."

### 4. A pushed typo? Leave it.
`b59b86c Update roadmap: swich done` was already pushed, so we **left it**. A small typo in history is fine. Rewriting shared history is worse.

---

## 🎯 Dart comparison

Git works the same for every language. Nothing changes between Flutter and .NET here.

---

## 🐞 Mistakes I actually made

| Mistake | What happened | Lesson |
|---|---|---|
| Only ran `git add` on 08, not 07 | The commit had 2 files instead of 4 | Check `git status` (all green?) **before** committing, and `git show --stat HEAD` after |
| Commit message without quotes | Vim opened and I got stuck | Always `-m "..."`. Escape Vim with Esc → `:cq` |
| `Updated ...` | Past tense | `Update ...` (present tense) |
| Very long message with the "why" | 65 characters | Short: say *what* changed |
| `swich`, `pratice`, `pjase`, `Imporve READMR` | Typos stay in history forever | Read the message before Enter |
| Thought `restore --staged` deleted my comment | VS Code hadn't refreshed | `--staged` **never** deletes edits |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| desk | **working directory** / **working tree** | "Your working tree is clean." |
| box | **staging area** (index) | "Stage only the files for this change." |
| latest photo | **HEAD** | "`git show HEAD` shows the last commit." |
| one topic per photo | **atomic commit** | "Split that into smaller, atomic commits." |
| retake the last photo | **amend** | "Don't amend pushed commits." |
| take out of the box | **unstage** | "I staged the bin folder by mistake, let me unstage it." |
| throw away edits | **discard changes** | "Discard your local changes and pull again." |
| new photo that undoes | **revert** | "That commit broke the build, let's revert it." |
| `:` scroll screen | **pager** | "Press q to quit the pager." |
| rewriting pushed commits | **rewriting history** | "Never rewrite shared history." |

---

## 📋 Summary

- Before every commit: `git status` + `git diff`. After: `git show --stat HEAD`
- Messages: verb first, present tense, short, one topic, in quotes
- `restore` = throw away edits · `restore --staged` = unstage (edits kept)
- `commit --amend` = fix the last commit, **only if it's not pushed**
- `revert <id>` = safely undo any commit, even a pushed one

---

## 📝 Quiz

1. What's the difference between `git restore file` and `git restore --staged file`?
2. You pushed a commit with a bug. Amend or revert? Why?
3. Rewrite this message: `fixed the bug where grade C crashed`
4. Why does `git diff` show nothing for a brand-new file?
5. You committed, but forgot one file. The commit isn't pushed. What 2 commands fix it and keep the message?

<details>
<summary>Answers</summary>

1. `restore` **deletes** your edits (back to the last commit). `restore --staged` only takes the file out of the staging area. Your edits stay.
2. **Revert.** The commit is pushed, so others may have it. Amend rewrites history (a new ID) and breaks their copy. Revert adds a new commit that undoes it.
3. `Fix crash for grade C` (verb first, present tense, short)
4. The file is **untracked**. Git has no old version to compare it with.
5. `git add <file>` then `git commit --amend --no-edit`

</details>
