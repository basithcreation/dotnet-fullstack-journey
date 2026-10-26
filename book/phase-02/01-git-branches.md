# Chapter 2.1: Git branches, a photocopy of the notebook

> Learned: theory Sat 24 Oct, practice Sun 25 Oct 2026 · Code: `projects/03-shipment-tracker` (branch `feature/menu-spacing`)

---

## 🧸 LKG story

**The official notebook and the photocopy.** The KPOST office has one **official notebook** with the clean, correct records. You never scribble in it while you try something new. Instead, you make a **photocopy** and do your work on the copy. If it goes well, you copy the new pages back into the official notebook and throw the photocopy away. If it goes badly, you just throw the photocopy away, and the official notebook was never touched.

The official notebook is `main`. The photocopy is a **branch**.

🎬 **Animation idea:** a horizontal line of commit dots labelled `main`. Pressing "switch -c" grows a second line (`feature/menu-spacing`) from the last dot. "commit" adds dots to whichever line has the `HEAD` arrow. "switch main" moves the arrow back. "merge" slides `main` forward to the feature's last dot (fast-forward). "branch -d" removes the label. Deleting a branch that isn't merged shows Git's warning.

---

## 💻 Real explanation

A **branch** is a separate line of commits. `main` stays clean while you work on a feature.

The whole flow, exactly as I ran it on the Shipment Tracker:

```
git switch -c feature/menu-spacing
```
```
Switched to a new branch 'feature/menu-spacing'
```

```
git branch
```
```
* feature/menu-spacing
  main
```
The `*` marks the branch you're on now.

Edit the code, then commit as usual (`git add` + `git commit -m "Move empty line above the menu"`). The commit goes onto **the branch**, not onto `main`.

```
git switch main
git merge feature/menu-spacing
```
```
Switched to branch 'main'
Updating b678519..e373c94
Fast-forward
 Program.cs | 1 +
 1 file changed, 1 insertion(+)
```
**Fast-forward** means `main` had no new commits of its own, so Git just slid `main` forward to the branch's last commit.

```
git branch -d feature/menu-spacing
git push
```
```
Deleted branch feature/menu-spacing (was e373c94).
```

| Command | Meaning |
|---|---|
| `git switch -c feature/x` | **c**reate a branch and switch to it |
| `git branch` | list the branches (`*` = current) |
| `git switch main` | go back to `main` |
| `git merge feature/x` | bring the branch's commits into the branch you're on |
| `git branch -d feature/x` | delete a branch that is already merged |

**Branch names:** `feature/...` for something new, `fix/...` for a bug fix. Lowercase, with dashes: `feature/menu-spacing`, `fix/index-zero`.

**In a team:** `main` is usually **protected**, so nobody can push to it directly. You push your branch and open a **pull request (PR)**. A teammate reviews it, then it gets merged.

From now on, **every project is built on its own branch**, never directly on `main`.

---

## 🎯 Dart comparison

Git is the same for every language. If your Flutter team used branches, it's exactly the same commands. The newer `git switch` replaces the older `git checkout` for changing branches. You'll see `checkout` in old tutorials, and it still works.

---

## 🐞 Things that can go wrong

| What you see | Why | Fix |
|---|---|---|
| `fatal: invalid reference: feature/menu` | a typo in the branch name | `git branch` to see the real name |
| `error: the branch 'fix/x' is not fully merged` | you tried `-d` on a branch whose commits aren't in `main` yet | merge it first. `-D` (capital) throws the work away, so only use it if you mean it |
| your commit is "missing" on `main` | you committed while on the branch, and didn't merge yet | `git switch main` + `git merge ...` |

---

## 🏢 Team words

| Easy word | Real term | Team sentence |
|---|---|---|
| a photocopy of the notebook | **branch** | "I'll do it on a feature branch." |
| copy the pages back | **merge** | "Merge it into main and delete the branch." |
| `main` just slides forward | **fast-forward merge** | "It was a fast-forward, no merge commit." |
| the official notebook | **`main`** (**protected**) | "Never push straight to main." |
| ask someone to check it | **pull request (PR)** | "I opened a PR for the menu fix." |

---

## 📋 Summary

| I want to... | Write |
|---|---|
| start new work | `git switch -c feature/name` |
| see where I am | `git branch` |
| go back | `git switch main` |
| bring the work in | `git merge feature/name` (while on `main`) |
| clean up | `git branch -d feature/name`, then `git push` |

---

## 📝 Quiz

1. In the story, what is `main`, and what is a branch?
2. Which command creates a branch **and** moves you onto it?
3. You want to merge `feature/x` into `main`. Which branch must you be on?
4. What does the `*` in `git branch` output mean?
5. Why do teams protect `main`?

<details>
<summary>Answers</summary>

1. `main` is the official notebook. A branch is a photocopy you work on.
2. `git switch -c feature/x`
3. On `main` (`git switch main` first, then `git merge feature/x`).
4. The branch you're on right now.
5. So nobody pushes broken code straight into it: changes go through a PR and a review first.

</details>
