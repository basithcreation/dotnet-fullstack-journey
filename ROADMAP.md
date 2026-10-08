# .NET Full Stack: From Zero to Pro 🚀
**C# · ASP.NET Core Web API · SQL Server · EF Core · Angular**

Owner: Abdul Basith · Start: Sunday 4 Oct 2026 · Length: ~28 weeks (26 study + 2 buffer) at ~16 hrs/week + your solo main project
Based on the original plan `NET From Zero to Job-Ready.docx` (kept as the source). Updated for full stack with Angular.

---

## How to use this plan
Learning .NET is like building a house. The roof (Web API, Angular) cannot go on before the walls (C#), and the walls need bricks (variables, loops). Each phase is one floor. Finish a floor, then climb up.

### Golden rules
1. **Type every line yourself.** Watching videos is like watching someone swim. You learn only by getting wet.
2. **Every phase ends with a project.** No project means the phase is not finished.
3. **Push everything to GitHub.** By the end, your GitHub is your portfolio. Each phase also has a small **🌿 Git skill** (branches in P2, PRs in P3, CI in P6, job-ready Git in P8), so you work like a team developer before you apply for jobs.
4. **Post on LinkedIn after every phase.** Learning in public builds your profile and keeps you consistent.
5. **Update your resume after every project.** See `career/RESUME.md`.

### Weekly rhythm (~16 hrs/week)
| Day | Time | What you do |
|---|---|---|
| Sun – Thu | 2 hrs | New lesson: learn, type the examples, do the exercise |
| Fri | 1.5 hrs | Light day: revise the week, quiz, write the LinkedIn post |
| Sat | 4–5 hrs | **Project day:** build the phase project, push to GitHub |

If a week gets busy, slide the plan forward. Do not skip. The 2 buffer weeks are for busy weeks, illness and Ramadan (expected around Feb–Mar 2027, depending on moon sighting).

**Your superpower:** you know **Dart/Flutter**. C# looks a lot like Dart: classes, async/await, generics and null safety will feel familiar. TypeScript (for Angular) will feel like Dart too.
**Honest note:** you are new to **JavaScript**, so Phase 9 teaches JS from zero. No shortcuts there.

---

## 🪜 Project ladder: small → big
Each phase has a **different** project, so you practise many kinds of apps.

| # | Phase | Project | Size |
|---|---|---|---|
| 00 | P0 | Greeting CLI | tiny |
| 01 | P1 | Number Guessing Game | tiny |
| 02 | P1 | Console Calculator | small |
| 03 | P1 | Shipment Tracker (in-memory) | small |
| 04 | P2 | Library Management (OOP) | small |
| 05 | P3 | Weather / Prayer-Time CLI (API + JSON + LINQ) | small–medium |
| 06 | P3.5 | Expense Tracker CLI (async files, disposal) | small–medium |
| 07 | P4 | E-commerce Database + 25 SQL queries | medium |
| 08 | P5 | School Management (EF Core) | medium |
| 09 | P6 | **Task Manager API** + Flutter client | medium |
| 10 | P7 | Task Manager API: Auth + Roles | medium |
| 11 | P8 | **Blog API** (Clean Architecture + CQRS + tests) | medium–large |
| 12 | P9 | Personal Portfolio Website (HTML/CSS/JS) | small |
| 13 | P9 | Todo App (vanilla JS → TypeScript) | small–medium |
| 14 | P10 | **Blog Frontend in Angular** | large |
| 15 | P11 | Real-time Chat (SignalR + Angular) + small MVC app | medium |
| 16 | P12 | Deploy Blog API + Angular with CI/CD | large |
| 17 | P13 | **Courier / Delivery Platform** (guided, full stack) | big |
| 18 | P14 | **YOUR Main Project** (solo, no help) | biggest |

Folder rule: exercises go in `lessons/phase-XX/`, projects go in `projects/NN-project-name/`.

---

## Phase 0: Meet .NET + Git (Week 1 · 4–10 Oct) ✅ done Tue 6 Oct 2026
🧸 **LKG story:** .NET is a big toy box from Microsoft. C# is the language you speak to the toys. The toys can become websites, APIs, desktop apps, games and mobile apps. Git is a time machine for your code: it saves photos of your work so you can always go back.

**Learn**
- [x] What .NET, C#, the CLR (the engine) and the SDK (the toolkit) are
- [x] .NET vs the old ".NET Framework". Learn only modern .NET (.NET 10 LTS)
- [x] Install: .NET SDK, Visual Studio 2022/2026 Community or VS Code + C# Dev Kit, Git
- [x] Commands: `dotnet new console`, `dotnet run`, `dotnet build`
- [x] Project structure: `.csproj`, `Program.cs`, `bin/`, `obj/`
- [x] **Git basics:** `init`, `add`, `commit`, `push`, `.gitignore`, a GitHub account, a README

**Project 00: Greeting CLI.** Ask for name and birth year, print a greeting and the age. Push to GitHub.
✅ **Done when:** you can create, run and push a console project without notes.
📣 **LinkedIn:** "Day 1 of my .NET journey: from Flutter dev to .NET full stack"
📄 **Resume:** add C# / .NET to your "Currently learning" line.

---

## Phase 1: C# Bricks (Weeks 2–3 · 11–24 Oct 2026)
🧸 **LKG story:** Variables are boxes with labels. `int age = 28;` means "a box named age that holds only whole numbers, and I put 28 in it". An `if` is a traffic light. A loop is a merry-go-round that keeps spinning until you say stop.

**Part 1: Boxes and choices**
- [x] Data types: `int`, `double`, `decimal` (use this for money!), `bool`, `char`, `string`
- [x] `var`, `const`, type conversion, `Parse` / `TryParse`
- [ ] Operators, string interpolation `$"Hi {name}"`
- [ ] `if` / `else`, `switch`, switch expressions

**Part 2: Merry-go-rounds and helpers**
- [ ] Loops: `for`, `while`, `do-while`, `foreach`, `break`, `continue`
- [ ] Arrays and `List<T>`
- [ ] Methods: parameters, return values, `ref`, `out`, optional and named parameters, overloading

**Part 3: Safety nets**
- [ ] Nullable types `int?` and null operators `?.` `??` `??=` (just like Dart!)
- [ ] Exceptions: `try` / `catch` / `finally`, throwing your own
- [ ] Debugging: breakpoints, step over/into, watch window. Learn this properly; it saves hundreds of hours

**🌿 Git skill (Phase 1): clean history + undo**
- [ ] Good commit messages (short, present tense: "Add parking meter v2"); commit small and often
- [ ] `git log --oneline`, `git diff`, `git status`: read what changed before you commit
- [ ] Undo mistakes: `git restore` (throw away edits), `git restore --staged` (un-add), `git revert` (undo a commit safely)

**Projects:** 01 Number Guessing Game (Part 1) → 02 Console Calculator (Part 2) → 03 Shipment Tracker: add, list, mark delivered, search by tracking number (Part 3)
✅ **Done when:** you can write a 100-line console app with loops, methods and error handling from scratch.
📣 **LinkedIn:** "3 things in C# that surprised me as a Dart developer"
📄 **Resume:** project bullet for the Shipment Tracker.

---

## Phase 2: Object-Oriented Programming (Week 4 · 25–31 Oct 2026)
🧸 **LKG story:** A class is a cookie cutter; an object is the cookie. Inheritance: a baby elephant gets its trunk from mama. An interface is a promise card: "anyone who signs this card MUST know how to `Borrow()`".

- [ ] Classes, objects, constructors, properties (`get; set;`, `init`, `required`)
- [ ] Access modifiers: `public`, `private`, `protected`, `internal`
- [ ] The 4 pillars: encapsulation, inheritance, polymorphism, abstraction
- [ ] `abstract` class vs `interface` (a very common interview question)
- [ ] `static`, `sealed`, `virtual` / `override`
- [ ] `struct` vs `class`, `record` types, `enum`
- [ ] SOLID principles: the simple idea of each one

**🌿 Git skill (Phase 2): branches**
- [ ] What a branch is; `git switch -c feature/...`, `git branch`, `git switch main`
- [ ] Merge a branch into `main`; delete it after; branch naming (`feature/`, `fix/`)
- [ ] From now on: every project is built on its own branch, never directly on `main`

**Project 04: Library Management.** `Book`, `Member`, `Loan`; `Member` base with `Student` / `Staff` children (different loan limits); interface `ILoanable`; late-fee calculation.
✅ **Done when:** you can explain the 4 pillars with your own example, out loud, in 2 minutes.
📣 **LinkedIn:** "OOP explained with cookies 🍪: my Library app in C#"
📄 **Resume:** "Designed an OOP library system in C# using inheritance, interfaces and polymorphism."

---

## Phase 3: C# Superpowers (Weeks 5–6 · 1–14 Nov 2026)
🧸 **LKG story:** Generics are a lunchbox that can hold any food, but once you decide it's for rice, only rice goes in. LINQ is asking your toy box a question: "give me all the red cars, sorted by size". async/await is putting rice on the stove and cutting vegetables while you wait, instead of staring at the pot.

**Part 1: Collections and generics**
- [ ] `List`, `Dictionary`, `HashSet`, `Queue`, `Stack`: when to use which
- [ ] Generic classes and methods, constraints (`where T : class`)
- [ ] `IEnumerable<T>` vs `ICollection<T>` vs `IList<T>`

**Part 2: LINQ and delegates**
- [ ] Delegates, `Func`, `Action`, lambdas `x => x * 2`
- [ ] LINQ: `Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, `First`, `Any`, `Sum`, `Count`
- [ ] Deferred execution (LINQ waits until you actually ask for results)
- [ ] Events (basic idea)

**Part 3: Async and files**
- [ ] `async` / `await`, `Task`, `Task<T>` (compare with Dart's `Future`)
- [ ] `HttpClient`: call a public API
- [ ] Read/write files; JSON with `System.Text.Json`
- [ ] Extension methods, pattern matching

**🌿 Git skill (Phase 3): pull requests + conflicts**
- [ ] Open your first **pull request (PR)** on GitHub: title, description, review, merge
- [ ] Create a **merge conflict** on purpose and resolve it (in VS Code and on the command line)
- [ ] `git pull` vs `git fetch`; `git stash` for "save my work for a moment"

**Project 05: Weather / Prayer-Time CLI.** Calls a free public API, parses JSON, filters with LINQ, saves history to a JSON file.
✅ **Done when:** you can write any LINQ query you need without searching for the syntax.
📣 **LinkedIn:** "LINQ is the best thing in C#. Here's why (with code)"
📄 **Resume:** "Built a CLI that consumes REST APIs with HttpClient, async/await and LINQ."

---

## Phase 3.5: Advanced C# (Week 7 · 15–21 Nov 2026) 🆕
🧸 **LKG story:** Your computer's memory is a room with two areas: a small, tidy **desk** (the stack) and a big **storeroom** (the heap). The garbage collector is the cleaner who throws away toys nobody is holding anymore.

- [ ] Value vs reference types in depth; stack vs heap; boxing and unboxing
- [ ] Garbage collection basics; `IDisposable`, `using`, `await using`
- [ ] Async pitfalls: `async void`, `.Result` / `.Wait()` deadlocks, `ConfigureAwait`, `CancellationToken`
- [ ] `IEnumerable` vs `IQueryable` (very important later for EF Core)
- [ ] Modern C#: primary constructors, collection expressions `[1, 2, 3]`, `required` members, raw string literals, file-scoped namespaces
- [ ] `yield return`, tuples, deconstruction

**Project 06: Expense Tracker CLI.** Categories, monthly report, async file storage, cancellation support, correct disposal.
✅ **Done when:** you can explain why `.Result` can freeze an app, and what `using` actually does.
📣 **LinkedIn:** "Stack vs Heap explained like you're 5"
📄 **Resume:** add "async programming, memory management" to skills.

---

## Phase 4: SQL Server, Basic to Advanced (Weeks 8–9 · 22 Nov–5 Dec 2026)
🧸 **LKG story:** A database is a giant cupboard with shelves (tables). Each shelf has rows of jars (records), and every jar has a sticker (primary key) so you never mix them up. SQL is how you talk to the cupboard: "give me all jars with mango".

**Part 1: Basics**
- [ ] Install SQL Server Developer Edition + SSMS (or Azure Data Studio)
- [ ] Tables, columns, data types, primary key, foreign key, constraints
- [ ] `SELECT`, `WHERE`, `ORDER BY`, `INSERT`, `UPDATE`, `DELETE`
- [ ] JOINs (inner, left, right, full), `GROUP BY`, `HAVING`, aggregates

**Part 2: Design and power tools**
- [ ] Normalization (1NF, 2NF, 3NF), ER diagrams
- [ ] Subqueries, **CTEs**, **window functions** (`ROW_NUMBER`, `RANK`, `SUM() OVER`)
- [ ] Views, stored procedures, functions

**Part 3: Pro level**
- [ ] Indexes (clustered vs non-clustered), **execution plans**, finding slow queries
- [ ] Transactions, ACID, **isolation levels**, locking and deadlocks
- [ ] Talk to SQL from C# with ADO.NET and **Dapper** (so you understand what EF Core hides)
- [ ] SQL injection and parameterized queries

**🌿 Git skill (Phases 4–5): work like a team**
- [ ] **GitHub Issues** as your to-do list; link a PR to an issue ("Closes #3")
- [ ] One PR per feature; write the PR description (what, why, how to test)
- [ ] Good README: setup steps, screenshots, tech list (recruiters read these)

**Project 07: E-commerce Database.** Customers, Products, Categories, Orders, OrderItems, Payments. Write 25 queries (e.g. "top 5 customers by spend this month", "running total of sales per day"). Read one execution plan and add an index that improves it.
✅ **Done when:** you can design a 6-table database and write JOIN + GROUP BY + window-function queries comfortably.
📣 **LinkedIn:** "I made a slow SQL query fast. Here's the execution plan before and after"
📄 **Resume:** "Designed a normalized SQL Server schema; optimized queries using indexes and execution plans."

---

## Phase 5: Entity Framework Core (Week 10 · 6–12 Dec 2026)
🧸 **LKG story:** EF Core is a translator robot. You speak C# ("add this student"), and the robot speaks SQL to the database for you.

**Part 1: Core**
- [ ] `DbContext` and `DbSet`
- [ ] Code-First, migrations (`dotnet ef migrations add`, `database update`)
- [ ] CRUD with EF Core
- [ ] Relationships: one-to-one, one-to-many, many-to-many
- [ ] Fluent API vs Data Annotations; seeding data

**Part 2: Pro**
- [ ] Loading: eager (`Include`), lazy, explicit; the **N+1 problem**
- [ ] `AsNoTracking`, projections with `Select`, logging the generated SQL
- [ ] **Concurrency tokens** (`rowversion`), **soft delete** (global query filters)
- [ ] **Auditing** with interceptors (CreatedAt / UpdatedAt automatically)
- [ ] Raw SQL when you need it; compiled queries (awareness)

**Project 08: School Management.** Students, Teachers, Courses, Enrollments (many-to-many), Grades. Migrations, seed data, soft delete, audit fields.
✅ **Done when:** you can go from an empty folder to a working database with relationships in under an hour.
📣 **LinkedIn:** "The N+1 problem almost got me. How I found it in EF Core"
📄 **Resume:** "Built a data layer with EF Core Code-First, migrations, soft delete and auditing."

---

## Phase 6: ASP.NET Core Web API ⭐ (Weeks 11–13 · 13 Dec 2026–2 Jan 2027), the most important phase
🧸 **LKG story:** A Web API is a restaurant waiter. Your app (the customer) asks: "one list of tasks please". The waiter (API) goes to the kitchen (database) and brings back the food (JSON). Controllers are the waiters, routes are the table numbers, and middleware is the security guard at the door checking everyone.

**Part 1: Basics**
- [ ] How HTTP works: GET, POST, PUT, PATCH, DELETE; status codes 200, 201, 204, 400, 401, 403, 404, 500
- [ ] Create a Web API project; `Program.cs`; controllers **and** Minimal APIs (learn both)
- [ ] Routing, attribute routing, model binding (`[FromBody]`, `[FromQuery]`, `[FromRoute]`)
- [ ] OpenAPI + Scalar / Swagger for testing; `.http` files; Postman

**Part 2: Doing it properly**
- [ ] **Dependency Injection** (Transient, Scoped, Singleton), an interview favourite
- [ ] DTOs (never send database entities directly), manual mapping / Mapster
- [ ] Validation: Data Annotations and FluentValidation
- [ ] `appsettings.json`, environments, Options pattern
- [ ] `Results` / `TypedResults`, async all the way, `CancellationToken` in endpoints

**Part 3: Grown-up features**
- [ ] Middleware pipeline, custom middleware, middleware order
- [ ] Global exception handling, `ProblemDetails`
- [ ] Logging with `ILogger` and **Serilog** (structured logs)
- [ ] Pagination, filtering, sorting, searching
- [ ] Filters (action, exception) vs middleware

**Part 4: Speed and extras**
- [ ] Caching (in-memory, output caching, Redis basics)
- [ ] CORS (needed so Angular can talk to your API)
- [ ] File upload/download
- [ ] API versioning, rate limiting
- [ ] Background jobs (`BackgroundService`, Hangfire basics)
- [ ] Health checks; OpenTelemetry basics (traces and metrics)

**🌿 Git skill (Phase 6): first CI pipeline**
- [ ] **GitHub Actions** basics: a workflow that runs `dotnet build` on every push and PR
- [ ] Read a failed pipeline log and fix it; status badge in the README
- [ ] Never commit secrets (`appsettings.Development.json`, connection strings); check `.gitignore`

**Project 09: Task Manager API.** Projects, Tasks, Tags, Comments. Full CRUD with EF Core + SQL Server, DTOs, validation, logging, pagination, global error handling, file attachments. Then **connect your Flutter app** to it. Flutter + .NET is a rare and very sellable combo.
✅ **Done when:** your Flutter app can list, create and update tasks through your own API.
📣 **LinkedIn:** "I built my first REST API in ASP.NET Core and connected it to Flutter 📱"
📄 **Resume:** "Developed a RESTful API with ASP.NET Core, EF Core and SQL Server (validation, pagination, structured logging); consumed from a Flutter client."

---

## Phase 7: Security & Authentication (Week 14 · 3–9 Jan 2027)
🧸 **LKG story:** Authentication is the guard asking "who are you?" and checking your ID card. Authorization is "OK, you're Abdul, but are you allowed in the manager's room?" A JWT is a wristband at a water park: show it at every ride, no need to show your ID again.

- [ ] ASP.NET Core Identity (users, roles, password hashing)
- [ ] JWT authentication, access + refresh tokens
- [ ] Role-based and policy-based authorization
- [ ] Secrets: User Secrets, environment variables; never commit passwords
- [ ] HTTPS, OWASP Top 10 basics, SQL injection, XSS, CSRF
- [ ] (Bonus) OAuth 2.0 / OpenID Connect concepts, Google login

**Project 10: Secure the Task Manager API.** Register/login, refresh tokens, roles (Admin, Member). Members see only their own projects.
✅ **Done when:** you can explain the JWT flow on a whiteboard. Your ISO 27001 background is a strong talking point here.
📣 **LinkedIn:** "JWT explained with a water-park wristband 🎢"
📄 **Resume:** "Implemented JWT authentication with refresh tokens and role/policy-based authorization."

---

## Phase 8: Architecture, Patterns & Testing (Weeks 15–16 · 10–23 Jan 2027)
🧸 **LKG story:** Clean Architecture is a well-organized school bag: books in one pocket, lunch in another, pencils in a small pouch. If the lunch leaks, the books stay dry.

**Part 1: Architecture**
- [ ] Layered / N-tier architecture
- [ ] Clean Architecture (Domain, Application, Infrastructure, API)
- [ ] Repository pattern + Unit of Work (and when NOT to use them)
- [ ] SOLID properly this time, with real code

**Part 2: Patterns**
- [ ] CQRS with MediatR (very common in Gulf enterprise jobs)
- [ ] Result pattern, Specification pattern
- [ ] Design patterns: Singleton, Factory, Strategy, Decorator, Observer

**Part 3: Testing**
- [ ] Unit tests with xUnit; Arrange-Act-Assert; test naming
- [ ] Mocking with Moq or NSubstitute
- [ ] Integration tests with `WebApplicationFactory`
- [ ] **Testcontainers** (a real SQL Server in Docker for tests)

**🌿 Git skill (Phase 8): job-ready Git** (you start applying after this phase)
- [ ] Add `dotnet test` to the GitHub Actions workflow; **branch protection** (PR must pass CI before merge)
- [ ] `git rebase` basics (keep your branch up to date with `main`); rebase vs merge
- [ ] Tags + GitHub **Releases** (`v1.0.0`); GitHub **profile README** + pinned repos
- [ ] Interview answer ready: "How do you use Git in a team?" (GitHub Flow: branch → commit → PR → review → CI → merge)

**Project 11: Blog API.** Users, Posts, Comments, Tags, Likes. Clean Architecture + CQRS, JWT, at least 20 unit tests and 5 integration tests.
✅ **Done when:** someone can open your repo and understand where everything lives in 2 minutes.
📣 **LinkedIn:** "My Blog API in Clean Architecture: folder structure explained"
📄 **Resume:** "Architected a Blog API using Clean Architecture, CQRS (MediatR) and xUnit/integration tests."

---

## Phase 9: Web Frontend Foundations, from zero (Weeks 17–19 · 24 Jan–13 Feb 2027) 🆕
🧸 **LKG story:** So far you built the kitchen. Now you build the dining room people see. **HTML** is the walls and furniture, **CSS** is the paint and decoration, and **JavaScript** is the electricity that makes things move and work.

**Part 1: HTML + CSS**
- [ ] HTML5: structure, semantic tags, links, images, lists, tables, **forms**
- [ ] CSS: selectors, box model, colors, fonts, units
- [ ] **Flexbox** and **Grid**; responsive design with media queries
- [ ] Browser DevTools (inspect, console, network tab)

**Part 2: JavaScript from zero (part 1)**
- [ ] Variables (`let`, `const`), types, operators, `if`, loops
- [ ] Functions, arrow functions, scope
- [ ] Arrays and objects, array methods (`map`, `filter`, `reduce`, which are LINQ's cousins!)
- [ ] The DOM: select elements, change them, events (`click`, `submit`)

**Part 3: JavaScript (part 2)**
- [ ] ES6+: destructuring, spread, template literals, modules (`import` / `export`)
- [ ] Promises, `async` / `await` (same idea as Dart's `Future`)
- [ ] `fetch`: call your own Task Manager API from the browser (CORS in practice!)
- [ ] `localStorage`, JSON, error handling
- [ ] npm basics: what `package.json` and `node_modules` are (never commit `node_modules`: `.gitignore` it)

**Part 4: TypeScript**
- [ ] Why TypeScript: JS with types (feels like Dart and C#)
- [ ] Types, interfaces, type aliases, unions, generics, enums
- [ ] Classes, access modifiers
- [ ] `tsconfig.json`, compiling TS

**Projects:** 12 Personal Portfolio Website (Parts 1–2): responsive, deployed free on GitHub Pages. 13 Todo App (Parts 3–4): vanilla JS with `localStorage`, then rewritten in TypeScript and connected to your API.
✅ **Done when:** you can build a responsive page and a small interactive app without a framework.
📣 **LinkedIn:** "I'm a backend dev learning JavaScript from zero. Week 1 lessons"
📄 **Resume:** add HTML5, CSS3, JavaScript, TypeScript. Link the portfolio site.

---

## Phase 10: Angular (Weeks 20–22 · 14 Feb–6 Mar 2027, likely Ramadan, so take it steady) 🆕 ⭐

> 🛟 **Buffer week 23 (7–13 Mar 2027):** catch up, or rest for Eid.
🧸 **LKG story:** Angular is a LEGO set for websites. Each LEGO brick is a **component** (header, post card, login form). **Services** are the delivery boys who bring data from the API. The **router** is the map that decides which room you see.

**Part 1: Basics**
- [ ] Angular CLI, project structure, standalone components
- [ ] Components, templates, data binding (interpolation, property, event, two-way)
- [ ] Control flow: `@if`, `@for`, `@switch`; pipes
- [ ] Component communication: `input()`, `output()`

**Part 2: Data and state**
- [ ] **Signals** (`signal`, `computed`, `effect`)
- [ ] Services and Dependency Injection (same idea as ASP.NET Core DI!)
- [ ] `HttpClient`, calling your Blog API; RxJS basics (`Observable`, `pipe`, `map`, `switchMap`)
- [ ] Routing: routes, params, lazy loading

**Part 3: Forms and security**
- [ ] Reactive Forms + validation (built-in and custom validators)
- [ ] Login with JWT: **HTTP interceptors** (attach token, refresh token), **route guards**
- [ ] Error handling and loading states

**Part 4: Polish**
- [ ] UI: Angular Material or Tailwind CSS
- [ ] Environments, build for production
- [ ] Testing basics (component and service tests)
- [ ] Performance: `OnPush`, `@defer`, track in `@for`

**Project 14: Blog Frontend in Angular.** Uses your Blog API: register/login, list posts with pagination, post details + comments, create/edit post (reactive forms), likes, admin-only pages (guards), responsive UI.
✅ **Done when:** a friend can register, log in, write a post and comment, entirely through your Angular app talking to your .NET API.
📣 **LinkedIn:** "Full stack achieved: .NET API + Angular frontend 🎉 (demo video)"
📄 **Resume:** "Built an Angular SPA (signals, reactive forms, JWT interceptors, route guards) integrated with an ASP.NET Core API."

---

## Phase 11: Real-time + MVC/Razor awareness (Week 24 · 14–20 Mar 2027)
🧸 **LKG story:** Normal APIs are like sending letters: you ask, then wait for a reply. **SignalR** is a phone call: the server can talk to you any time.

- [ ] SignalR: hubs, groups, sending to users; Angular SignalR client
- [ ] ASP.NET Core MVC + Razor Pages tour: layouts, partials, tag helpers, forms. Many Kuwait banks, government and ERP systems still use this
- [ ] Blazor overview: what it is, when companies choose it

**Project 15:** Real-time Chat (SignalR + Angular: rooms, online users, typing indicator) + a small MVC "Contact Book" app.
✅ **Done when:** two browser windows chat live through your server.
📣 **LinkedIn:** "Real-time chat with SignalR + Angular in one weekend"
📄 **Resume:** "Implemented real-time messaging with SignalR."

---

## Phase 12: Deploy & DevOps (Week 25 · 21–27 Mar 2027)
🧸 **LKG story:** Your app works on your laptop; that's your house. Deployment is moving it to a shop in the market (the cloud) so everyone can visit. Docker is a lunchbox that packs your app with everything it needs, so it tastes the same anywhere.

- [ ] Git advanced (branches, PRs, conflicts, rebase were learned in Phases 2–8): interactive rebase / squash, `cherry-pick`, `reset` vs `revert`, GitHub Flow vs Git Flow
- [ ] Docker: Dockerfile, images, containers, docker-compose (API + SQL Server + Angular together)
- [ ] Deploy to Azure App Service + Azure SQL (free tier / credits); Angular to Azure Static Web Apps or similar
- [ ] IIS hosting on Windows Server (common in Kuwait on-premise companies)
- [ ] CI/CD with GitHub Actions: build → test → deploy on every push
- [ ] Health checks, logs and monitoring in production
- [ ] (Optional) .NET Aspire for local orchestration

**Project 16:** Blog API + Angular frontend live on the internet with a GitHub Actions pipeline.
✅ **Done when:** you push code and it deploys itself.
📣 **LinkedIn:** "git push → live in production. My CI/CD pipeline explained"
📄 **Resume:** "Containerized with Docker and deployed to Azure via GitHub Actions CI/CD."

---

## Phase 13: Guided Full-Stack Project + Interview Prep (Weeks 26–27 · 28 Mar–10 Apr 2027)

> 🛟 **Buffer week 28 (11–17 Apr 2027):** finish anything left over.
🧸 **LKG story:** You've learned your letters, words and sentences. Now you write a real story book, with the teacher sitting next to you one last time.

**Project 17: Courier / Delivery Platform (guided).** This brings everything together:
- .NET API in Clean Architecture, EF Core + SQL Server, JWT + roles (Admin, Driver, Customer)
- **Angular** admin dashboard (shipments, assign drivers, charts)
- **Flutter** driver app (my deliveries, update status)
- **SignalR** live shipment tracking
- Tests, Docker, CI/CD, live URL, a strong README with screenshots and an architecture diagram

**Interview prep**
- [ ] C#: value vs reference, `IEnumerable` vs `IQueryable`, async deadlocks, abstract vs interface, boxing, GC, `ref` vs `out`
- [ ] ASP.NET Core: middleware order, DI lifetimes, filters vs middleware, JWT, REST best practices
- [ ] SQL: joins, indexes, execution plans, isolation levels, transactions
- [ ] Angular: change detection, signals vs observables, lifecycle hooks, interceptors, guards, lazy loading
- [ ] 2 LeetCode Easy/Medium problems a day in C#
- [ ] Mock interviews with me ("interview me")
- [ ] Final CV, LinkedIn and portfolio polish → apply to .NET full-stack roles in Kuwait and the Gulf

📣 **LinkedIn:** "6 months ago I couldn't write C#. Here's what I built"

---

## Phase 14: YOUR Main Project (solo, no help) 🏆
You will bring your own project idea. This phase proves you are a real developer.

**Rules (Solo mode)**
- I do **not** write code, give hints or give solutions, even if you ask.
- I **do**: (1) review your design document before you start (requirements, DB diagram, API endpoints, screens), (2) review your code after each feature, like a senior developer reviewing a pull request, and (3) run mock interviews about your project.
- You can say "exit solo mode" if you really need to, but try not to!

**Steps**
- [ ] Write the design document (problem, users, features, DB schema, endpoints, screens)
- [ ] Design review with me
- [ ] Build feature by feature; open a PR for each; code review with me
- [ ] Tests, Docker, CI/CD, live URL, README
- [ ] Demo video + LinkedIn launch post + resume headline project

---

## Phase 15: Keep Growing (after the main project)
- Microservices, message queues (RabbitMQ, Azure Service Bus), gRPC
- .NET Aspire, distributed tracing in depth
- .NET MAUI (C# mobile, interesting to compare with Flutter)
- Performance: `Span<T>`, memory profiling, BenchmarkDotNet
- Microsoft certification: **Azure Developer Associate (AZ-204)**

---

## Resources
| Need | Resource |
|---|---|
| Official path (free) | Microsoft Learn: C# and ASP.NET Core learning paths |
| C# basics (free) | Microsoft "C# for Beginners", freeCodeCamp Foundational C# certification |
| Modern ASP.NET Core | Your Udemy .NET course; Nick Chapsas; Milan Jovanović |
| SQL | Microsoft Learn T-SQL; Brent Ozar (performance, later) |
| HTML / CSS / JS | MDN Web Docs; javascript.info; freeCodeCamp Responsive Web Design |
| TypeScript | TypeScript Handbook (typescriptlang.org) |
| Angular | angular.dev (official tutorial); Deborah Kurata; Decoded Frontend |
| Practice | Exercism C# track, LeetCode, HackerRank |
| Docs | learn.microsoft.com/dotnet |
| Books (later) | *C# in Depth* (Jon Skeet), *Clean Architecture* (Robert C. Martin) |

---

## Progress tracker
Legend: ⬜ not started · 🟨 in progress · ✅ done

| Phase | Planned | Project(s) | Status | LinkedIn posted | Finished on |
|---|---|---|---|---|---|
| 0: Meet .NET + Git | W1 · Oct 4–10 | 00 | ✅ | ✅ | 6 Oct 2026 |
| 1: C# Bricks | W2–3 · Oct 11–24 | 01, 02, 03 | ⬜ | ⬜ |  |
| 2: OOP | W4 · Oct 25–31 | 04 | ⬜ | ⬜ |  |
| 3: C# Superpowers | W5–6 · Nov 1–14 | 05 | ⬜ | ⬜ |  |
| 3.5: Advanced C# | W7 · Nov 15–21 | 06 | ⬜ | ⬜ |  |
| 4: SQL Server | W8–9 · Nov 22–Dec 5 | 07 | ⬜ | ⬜ |  |
| 5: EF Core | W10 · Dec 6–12 | 08 | ⬜ | ⬜ |  |
| 6: Web API ⭐ | W11–13 · Dec 13–Jan 2 | 09 | ⬜ | ⬜ |  |
| 7: Security | W14 · Jan 3–9 | 10 | ⬜ | ⬜ |  |
| 8: Architecture & Testing | W15–16 · Jan 10–23 | 11 | ⬜ | ⬜ |  |
| 9: HTML / CSS / JS / TS | W17–19 · Jan 24–Feb 13 | 12, 13 | ⬜ | ⬜ |  |
| 10: Angular ⭐ | W20–22 · Feb 14–Mar 6 | 14 | ⬜ | ⬜ |  |
| 11: SignalR + MVC | W24 · Mar 14–20 | 15 | ⬜ | ⬜ |  |
| 12: Deploy & DevOps | W25 · Mar 21–27 | 16 | ⬜ | ⬜ |  |
| 13: Guided Project + Interviews | W26–27 · Mar 28–Apr 10 | 17 | ⬜ | ⬜ |  |
| 14: YOUR Main Project 🏆 | solo | 18 | ⬜ | ⬜ | |

Start: Sunday 4 Oct 2026 → guided path ends around mid-April 2027 → then your solo main project.

**Job plan:** keep your current job. Start applying for **junior .NET backend** roles after Phase 8 (late Jan 2027) and **junior full-stack** roles after Phase 10 (Mar 2027). Resign only with a signed offer.
