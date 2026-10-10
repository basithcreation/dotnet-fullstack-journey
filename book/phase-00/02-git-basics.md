# Chapter 0.2: Git basics, a time machine for code

> Learned: Tue 6 Oct 2026 · Repo: https://github.com/basithcreation/dotnet-fullstack-journey

---

## 🧸 LKG story

Git is a **photo album** for your code.

- 📝 You work on your files at your **desk**.
- 📦 You put the pages you want in the photo into a **box**.
- 📸 You take a **photo** of the box and write a caption under it.
- ☁️ You upload the album to **GitHub** so it's safe, and so others can see it.

If you break something tomorrow, you open the album and go back to yesterday's photo.

🎬 **Animation idea:** a desk with papers → some papers move into a box (`git add`) → a camera flash (`git commit`) → the photo lands in an album → the album flies up into a cloud (`git push`).

---

## 💻 Real explanation

| LKG | Real term | Command |
|---|---|---|
| desk | **working directory** (your files right now) | (just edit files) |
| box | **staging area** (what goes into the next commit) | `git add` |
| photo + caption | **commit** + **commit message** | `git commit -m "..."` |
| album on your PC | **local repository** (the hidden `.git` folder) | `git init` |
| album in the cloud | **remote repository** (GitHub) | `git push` |

### First-time setup of a project

```
git init                          // start a new repo in this folder
git add .                         // stage all files
git commit -m "Add greeting CLI"  // take the first photo
git remote add origin <url>       // connect to the GitHub repo
git push -u origin main           // upload (-u: remember this remote for next time)
```

After that, the daily loop is:
```
git status                  // what changed?
git add <files>             // put them in the box
git commit -m "message"     // take the photo
git push                    // upload
```

### `.gitignore`: what Git should NOT save

A `.gitignore` file lists files and folders Git must ignore. For .NET, create it with:
```
dotnet new gitignore
```
It already ignores `bin/`, `obj/`, `.vs/` and other generated files.

`git status --untracked-files=all` shows **every** new file, so you can check nothing unwanted slips in.

### README

`README.md` is the **front page** of your repo on GitHub. It's written in **Markdown**:
```markdown
# Project title
Short description.

## How to run
    dotnet run
```

### Important ideas

- A **commit is a local snapshot** of all your staged files. It's **not** only a message, and it's **not** on GitHub until you `push`.
- Git only saves what you **commit**. Edits you didn't commit can be lost, so **commit often**.
- The warning `LF will be replaced by CRLF` is about invisible line-ending characters (Windows vs Linux). It's **harmless**.
- Use your **personal** email in Git for your own portfolio, not your work email: `git config --global user.email "you@example.com"`

---

## 🎯 Dart comparison

Git is the same for every language. The only difference is the ignore file:

| Flutter | .NET |
|---|---|
| Ignore `build/`, `.dart_tool/` | Ignore `bin/`, `obj/`, `.vs/` |
| `flutter create` makes a `.gitignore` for you | `dotnet new gitignore` |

---

## 🐞 Errors and lessons from my repo

| What happened | Lesson |
|---|---|
| Commit message `Imporve READMR` (2 typos) and `Complete pjase 0` | Read your message before pressing Enter. Typos stay in the history forever. |
| Git was using my **work** email | Changed it to the personal email for my portfolio |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| photo album | **repository** (repo) | "Clone the repo and run it." |
| photo | **commit** | "Commit small and often." |
| box | **staging area** | "Stage only what belongs in this commit." |
| upload | **push** | "Push your branch when you're done." |
| GitHub copy | **remote** (`origin`) | "Is it pushed to origin?" |
| ignore list | **.gitignore** | "Add the bin folder to .gitignore." |

---

## 📋 Summary

- Desk → box → photo → cloud = edit → `git add` → `git commit` → `git push`
- `git status` tells you what changed. Check it often.
- `.gitignore` keeps `bin/` and `obj/` out of the repo
- A commit is a **local** snapshot. Push to put it on GitHub.
- Commit often: Git can only bring back what you committed

---

## 📝 Quiz

1. What is the difference between `git commit` and `git push`?
2. You edited a file but didn't commit it, and then your laptop died. Can Git bring the edit back?
3. What does `git add` do?
4. Which command creates a .NET `.gitignore`?
5. Is the warning "LF will be replaced by CRLF" a problem?

<details>
<summary>Answers</summary>

1. `commit` takes a snapshot **on your PC**. `push` uploads your commits **to GitHub**.
2. No. Git only saves what you **commit**. That's why we commit often.
3. It puts files into the **staging area** (the box), so they go into the next commit.
4. `dotnet new gitignore`
5. No. It's only about invisible line-ending characters (Windows uses CRLF, Linux/Mac use LF). Git converts them automatically.

</details>
