# .NET Full Stack: From Zero to Pro 🚀
**C# · ASP.NET Core Web API · SQL Server · EF Core · Angular**

Owner: Abdul Basith · Start: Sunday 4 Oct 2026 · Length: ~38 weeks + your solo main project
Based on the original plan `NET From Zero to Job-Ready.docx` (kept as the source). Updated for full stack with Angular.

---

## How to use this plan
Learning .NET is like building a house. The roof (Web API, Angular) cannot go on before the walls (C#), and the walls need bricks (variables, loops). Each phase is one floor. Finish a floor, then climb up.

### Golden rules
1. **Type every line yourself.** Watching videos is like watching someone swim. You learn only by getting wet.
2. **Every phase ends with a project.** No project means the phase is not finished.
3. **Push everything to GitHub.** By the end, your GitHub is your portfolio.
4. **Post on LinkedIn after every phase.** Learning in public builds your profile and keeps you consistent.
5. **Update your resume after every project.** See `career/RESUME.md`.

### Weekly rhythm (Kuwait week, evenings, ~10–11 hrs)
| Day | Time | What you do |
|---|---|---|
| Sun – Wed | 1.5 hrs | Learn the new topic and type the examples |
| Thu | 1 hr | Revise the week, fix what confused you, take the quiz |
| Fri | 3 hrs | Build the week's project |
| Sat | 1–2 hrs | Light practice (Exercism / LeetCode Easy), write the LinkedIn post, or rest |

If a week gets busy, slide the plan forward. Do not skip.

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

## Phase 0: Meet .NET + Git (Week 1) ✅ done Tue 6 Oct 2026
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

## Phase 1: C# Bricks (Weeks 2–4)
🧸 **LKG story:** Variables are boxes with labels. `int age = 28;` means "a box named age that holds only whole numbers, and I put 28 in it". An `if` is a traffic light. A loop is a merry-go-round that keeps spinning until you say stop.

**Week 2: Boxes and choices**
- [ ] Data types: `int`, `double`, `decimal` (use this for money!), `bool`, `char`, `string`
- [ ] `var`, `const`, type conversion, `Parse` / `TryParse`
- [ ] Operators, string interpolation `$"Hi {name}"`
- [ ] `if` / `else`, `switch`, switch expressions

**Week 3: Merry-go-rounds and helpers**
- [ ] Loops: `for`, `while`, `do-while`, `foreach`, `break`, `continue`
- [ ] Arrays and `List<T>`
- [ ] Methods: parameters, return values, `ref`, `out`, optional and named parameters, overloading

**Week 4: Safety nets**
- [ ] Nullable types `int?` and null operators `?.` `??` `??=` (just like Dart!)
- [ ] Exceptions: `try` / `catch` / `finally`, throwing your own
- [ ] Debugging: breakpoints, step over/into, watch window. Learn this properly; it saves hundreds of hours

**Projects:** 01 Number Guessing Game (W2) → 02 Console Calculator (W3) → 03 Shipment Tracker: add, list, mark delivered, search by tracking number (W4)
✅ **Done when:** you can write a 100-line console app with loops, methods and error handling from scratch.
📣 **LinkedIn:** "3 things in C# that surprised me as a Dart developer"
📄 **Resume:** project bullet for the Shipment Tracker.

---

## Phase 2: Object-Oriented Programming (Weeks 5–6)
🧸 **LKG story:** A class is a cookie cutter; an object is the cookie. Inheritance: a baby elephant gets its trunk from mama. An interface is a promise card: "anyone who signs this card MUST know how to `Borrow()`".

- [ ] Classes, objects, constructors, properties (`get; set;`, `init`, `required`)
- [ ] Access modifiers: `public`, `private`, `protected`, `internal`
- [ ] The 4 pillars: encapsulation, inheritance, polymorphism, abstraction
- [ ] `abstract` class vs `interface` (a very common interview question)
- [ ] `static`, `sealed`, `virtual` / `override`
- [ ] `struct` vs `class`, `record` types, `enum`
- [ ] SOLID principles: the simple idea of each one

**Project 04: Library Management.** `Book`, `Member`, `Loan`; `Member` base with `Student` / `Staff` children (different loan limits); interface `ILoanable`; late-fee calculation.
✅ **Done when:** you can explain the 4 pillars with your own example, out loud, in 2 minutes.
📣 **LinkedIn:** "OOP explained with cookies 🍪: my Library app in C#"
📄 **Resume:** "Designed an OOP library system in C# using inheritance, interfaces and polymorphism."

---

## Phase 3: C# Superpowers (Weeks 7–9)
🧸 **LKG story:** Generics are a lunchbox that can hold any food, but once you decide it's for rice, only rice goes in. LINQ is asking your toy box a question: "give me all the red cars, sorted by size". async/await is putting rice on the stove and cutting vegetables while you wait, instead of staring at the pot.

**Week 7: Collections and generics**
- [ ] `List`, `Dictionary`, `HashSet`, `Queue`, `Stack`: when to use which
- [ ] Generic classes and methods, constraints (`where T : class`)
- [ ] `IEnumerable<T>` vs `ICollection<T>` vs `IList<T>`

**Week 8: LINQ and delegates**
- [ ] Delegates, `Func`, `Action`, lambdas `x => x * 2`
- [ ] LINQ: `Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, `First`, `Any`, `Sum`, `Count`
- [ ] Deferred execution (LINQ waits until you actually ask for results)
- [ ] Events (basic idea)

**Week 9: Async and files**
- [ ] `async` / `await`, `Task`, `Task<T>` (compare with Dart's `Future`)
- [ ] `HttpClient`: call a public API
- [ ] Read/write files; JSON with `System.Text.Json`
- [ ] Extension methods, pattern matching

**Project 05: Weather / Prayer-Time CLI.** Calls a free public API, parses JSON, filters with LINQ, saves history to a JSON file.
✅ **Done when:** you can write any LINQ query you need without searching for the syntax.
📣 **LinkedIn:** "LINQ is the best thing in C#. Here's why (with code)"
📄 **Resume:** "Built a CLI that consumes REST APIs with HttpClient, async/await and LINQ."

---

## Phase 3.5: Advanced C# (Week 10) 🆕
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

## Phase 4: SQL Server, Basic to Advanced (Weeks 11–13)
🧸 **LKG story:** A database is a giant cupboard with shelves (tables). Each shelf has rows of jars (records), and every jar has a sticker (primary key) so you never mix them up. SQL is how you talk to the cupboard: "give me all jars with mango".

**Week 11: Basics**
- [ ] Install SQL Server Developer Edition + SSMS (or Azure Data Studio)
- [ ] Tables, columns, data types, primary key, foreign key, constraints
- [ ] `SELECT`, `WHERE`, `ORDER BY`, `INSERT`, `UPDATE`, `DELETE`
- [ ] JOINs (inner, left, right, full), `GROUP BY`, `HAVING`, aggregates

**Week 12: Design and power tools**
- [ ] Normalization (1NF, 2NF, 3NF), ER diagrams
- [ ] Subqueries, **CTEs**, **window functions** (`ROW_NUMBER`, `RANK`, `SUM() OVER`)
- [ ] Views, stored procedures, functions

**Week 13: Pro level**
- [ ] Indexes (clustered vs non-clustered), **execution plans**, finding slow queries
- [ ] Transactions, ACID, **isolation levels**, locking and deadlocks
- [ ] Talk to SQL from C# with ADO.NET and **Dapper** (so you understand what EF Core hides)
- [ ] SQL injection and parameterized queries

**Project 07: E-commerce Database.** Customers, Products, Categories, Orders, OrderItems, Payments. Write 25 queries (e.g. "top 5 customers by spend this month", "running total of sales per day"). Read one execution plan and add an index that improves it.
✅ **Done when:** you can design a 6-table database and write JOIN + GROUP BY + window-function queries comfortably.
📣 **LinkedIn:** "I made a slow SQL query fast. Here's the execution plan before and after"
📄 **Resume:** "Designed a normalized SQL Server schema; optimized queries using indexes and execution plans."

---

## Phase 5: Entity Framework Core (Weeks 14–15)
🧸 **LKG story:** EF Core is a translator robot. You speak C# ("add this student"), and the robot speaks SQL to the database for you.

**Week 14: Core**
- [ ] `DbContext` and `DbSet`
- [ ] Code-First, migrations (`dotnet ef migrations add`, `database update`)
- [ ] CRUD with EF Core
- [ ] Relationships: one-to-one, one-to-many, many-to-many
- [ ] Fluent API vs Data Annotations; seeding data

**Week 15: Pro**
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

## Phase 6: ASP.NET Core Web API ⭐ (Weeks 16–19), the most important phase
🧸 **LKG story:** A Web API is a restaurant waiter. Your app (the customer) asks: "one list of tasks please". The waiter (API) goes to the kitchen (database) and brings back the food (JSON). Controllers are the waiters, routes are the table numbers, and middleware is the security guard at the door checking everyone.

**Week 16: Basics**
- [ ] How HTTP works: GET, POST, PUT, PATCH, DELETE; status codes 200, 201, 204, 400, 401, 403, 404, 500
- [ ] Create a Web API project; `Program.cs`; controllers **and** Minimal APIs (learn both)
- [ ] Routing, attribute routing, model binding (`[FromBody]`, `[FromQuery]`, `[FromRoute]`)
- [ ] OpenAPI + Scalar / Swagger for testing; `.http` files; Postman

**Week 17: Doing it properly**
- [ ] **Dependency Injection** (Transient, Scoped, Singleton), an interview favourite
- [ ] DTOs (never send database entities directly), manual mapping / Mapster
- [ ] Validation: Data Annotations and FluentValidation
- [ ] `appsettings.json`, environments, Options pattern
- [ ] `Results` / `TypedResults`, async all the way, `CancellationToken` in endpoints

**Week 18: Grown-up features**
- [ ] Middleware pipeline, custom middleware, middleware order
- [ ] Global exception handling, `ProblemDetails`
- [ ] Logging with `ILogger` and **Serilog** (structured logs)
- [ ] Pagination, filtering, sorting, searching
- [ ] Filters (action, exception) vs middleware

**Week 19: Speed and extras**
- [ ] Caching (in-memory, output caching, Redis basics)
- [ ] CORS (needed so Angular can talk to your API)
- [ ] File upload/download
- [ ] API versioning, rate limiting
- [ ] Background jobs (`BackgroundService`, Hangfire basics)
- [ ] Health checks; OpenTelemetry basics (traces and metrics)

**Project 09: Task Manager API.** Projects, Tasks, Tags, Comments. Full CRUD with EF Core + SQL Server, DTOs, validation, logging, pagination, global error handling, file attachments. Then **connect your Flutter app** to it. Flutter + .NET is a rare and very sellable combo.
✅ **Done when:** your Flutter app can list, create and update tasks through your own API.
📣 **LinkedIn:** "I built my first REST API in ASP.NET Core and connected it to Flutter 📱"
📄 **Resume:** "Developed a RESTful API with ASP.NET Core, EF Core and SQL Server (validation, pagination, structured logging); consumed from a Flutter client."

---

## Phase 7: Security & Authentication (Weeks 20–21)
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

## Phase 8: Architecture, Patterns & Testing (Weeks 22–24)
🧸 **LKG story:** Clean Architecture is a well-organized school bag: books in one pocket, lunch in another, pencils in a small pouch. If the lunch leaks, the books stay dry.

**Week 22: Architecture**
- [ ] Layered / N-tier architecture
- [ ] Clean Architecture (Domain, Application, Infrastructure, API)
- [ ] Repository pattern + Unit of Work (and when NOT to use them)
- [ ] SOLID properly this time, with real code

**Week 23: Patterns**
- [ ] CQRS with MediatR (very common in Gulf enterprise jobs)
- [ ] Result pattern, Specification pattern
- [ ] Design patterns: Singleton, Factory, Strategy, Decorator, Observer

**Week 24: Testing**
- [ ] Unit tests with xUnit; Arrange-Act-Assert; test naming
- [ ] Mocking with Moq or NSubstitute
- [ ] Integration tests with `WebApplicationFactory`
- [ ] **Testcontainers** (a real SQL Server in Docker for tests)

**Project 11: Blog API.** Users, Posts, Comments, Tags, Likes. Clean Architecture + CQRS, JWT, at least 20 unit tests and 5 integration tests.
✅ **Done when:** someone can open your repo and understand where everything lives in 2 minutes.
📣 **LinkedIn:** "My Blog API in Clean Architecture: folder structure explained"
📄 **Resume:** "Architected a Blog API using Clean Architecture, CQRS (MediatR) and xUnit/integration tests."

---

## Phase 9: Web Frontend Foundations, from zero (Weeks 25–28) 🆕
🧸 **LKG story:** So far you built the kitchen. Now you build the dining room people see. **HTML** is the walls and furniture, **CSS** is the paint and decoration, and **JavaScript** is the electricity that makes things move and work.

**Week 25: HTML + CSS**
- [ ] HTML5: structure, semantic tags, links, images, lists, tables, **forms**
- [ ] CSS: selectors, box model, colors, fonts, units
- [ ] **Flexbox** and **Grid**; responsive design with media queries
- [ ] Browser DevTools (inspect, console, network tab)

**Week 26: JavaScript from zero (part 1)**
- [ ] Variables (`let`, `const`), types, operators, `if`, loops
- [ ] Functions, arrow functions, scope
- [ ] Arrays and objects, array methods (`map`, `filter`, `reduce`, which are LINQ's cousins!)
- [ ] The DOM: select elements, change them, events (`click`, `submit`)

**Week 27: JavaScript (part 2)**
- [ ] ES6+: destructuring, spread, template literals, modules (`import` / `export`)
- [ ] Promises, `async` / `await` (same idea as Dart's `Future`)
- [ ] `fetch`: call your own Task Manager API from the browser (CORS in practice!)
- [ ] `localStorage`, JSON, error handling
- [ ] npm basics: what `package.json` and `node_modules` are

**Week 28: TypeScript**
- [ ] Why TypeScript: JS with types (feels like Dart and C#)
- [ ] Types, interfaces, type aliases, unions, generics, enums
- [ ] Classes, access modifiers
- [ ] `tsconfig.json`, compiling TS

**Projects:** 12 Personal Portfolio Website (W25–26): responsive, deployed free on GitHub Pages. 13 Todo App (W27–28): vanilla JS with `localStorage`, then rewritten in TypeScript and connected to your API.
✅ **Done when:** you can build a responsive page and a small interactive app without a framework.
📣 **LinkedIn:** "I'm a backend dev learning JavaScript from zero. Week 1 lessons"
📄 **Resume:** add HTML5, CSS3, JavaScript, TypeScript. Link the portfolio site.

---

## Phase 10: Angular (Weeks 29–32) 🆕 ⭐
🧸 **LKG story:** Angular is a LEGO set for websites. Each LEGO brick is a **component** (header, post card, login form). **Services** are the delivery boys who bring data from the API. The **router** is the map that decides which room you see.

**Week 29: Basics**
- [ ] Angular CLI, project structure, standalone components
- [ ] Components, templates, data binding (interpolation, property, event, two-way)
- [ ] Control flow: `@if`, `@for`, `@switch`; pipes
- [ ] Component communication: `input()`, `output()`

**Week 30: Data and state**
- [ ] **Signals** (`signal`, `computed`, `effect`)
- [ ] Services and Dependency Injection (same idea as ASP.NET Core DI!)
- [ ] `HttpClient`, calling your Blog API; RxJS basics (`Observable`, `pipe`, `map`, `switchMap`)
- [ ] Routing: routes, params, lazy loading

**Week 31: Forms and security**
- [ ] Reactive Forms + validation (built-in and custom validators)
- [ ] Login with JWT: **HTTP interceptors** (attach token, refresh token), **route guards**
- [ ] Error handling and loading states

**Week 32: Polish**
- [ ] UI: Angular Material or Tailwind CSS
- [ ] Environments, build for production
- [ ] Testing basics (component and service tests)
- [ ] Performance: `OnPush`, `@defer`, track in `@for`

**Project 14: Blog Frontend in Angular.** Uses your Blog API: register/login, list posts with pagination, post details + comments, create/edit post (reactive forms), likes, admin-only pages (guards), responsive UI.
✅ **Done when:** a friend can register, log in, write a post and comment, entirely through your Angular app talking to your .NET API.
📣 **LinkedIn:** "Full stack achieved: .NET API + Angular frontend 🎉 (demo video)"
📄 **Resume:** "Built an Angular SPA (signals, reactive forms, JWT interceptors, route guards) integrated with an ASP.NET Core API."

---

## Phase 11: Real-time + MVC/Razor awareness (Week 33)
🧸 **LKG story:** Normal APIs are like sending letters: you ask, then wait for a reply. **SignalR** is a phone call: the server can talk to you any time.

- [ ] SignalR: hubs, groups, sending to users; Angular SignalR client
- [ ] ASP.NET Core MVC + Razor Pages tour: layouts, partials, tag helpers, forms. Many Kuwait banks, government and ERP systems still use this
- [ ] Blazor overview: what it is, when companies choose it

**Project 15:** Real-time Chat (SignalR + Angular: rooms, online users, typing indicator) + a small MVC "Contact Book" app.
✅ **Done when:** two browser windows chat live through your server.
📣 **LinkedIn:** "Real-time chat with SignalR + Angular in one weekend"
📄 **Resume:** "Implemented real-time messaging with SignalR."

---

## Phase 12: Deploy & DevOps (Weeks 34–35)
🧸 **LKG story:** Your app works on your laptop; that's your house. Deployment is moving it to a shop in the market (the cloud) so everyone can visit. Docker is a lunchbox that packs your app with everything it needs, so it tastes the same anywhere.

- [ ] Git properly: branches, pull requests, merge conflicts, rebasing basics
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

## Phase 13: Guided Full-Stack Project + Interview Prep (Weeks 36–38)
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

📣 **LinkedIn:** "38 weeks ago I couldn't write C#. Here's what I built"

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

| Phase | Weeks | Project(s) | Status | LinkedIn posted | Finished on |
|---|---|---|---|---|---|
| 0: Meet .NET + Git | 1 | 00 | ✅ | ✅ | 6 Oct 2026 |
| 1: C# Bricks | 2–4 | 01, 02, 03 | ⬜ | ⬜ |  |
| 2: OOP | 5–6 | 04 | ⬜ | ⬜ |  |
| 3: C# Superpowers | 7–9 | 05 | ⬜ | ⬜ |  |
| 3.5: Advanced C# | 10 | 06 | ⬜ | ⬜ |  |
| 4: SQL Server | 11–13 | 07 | ⬜ | ⬜ |  |
| 5: EF Core | 14–15 | 08 | ⬜ | ⬜ |  |
| 6: Web API ⭐ | 16–19 | 09 | ⬜ | ⬜ |  |
| 7: Security | 20–21 | 10 | ⬜ | ⬜ |  |
| 8: Architecture & Testing | 22–24 | 11 | ⬜ | ⬜ |  |
| 9: HTML / CSS / JS / TS | 25–28 | 12, 13 | ⬜ | ⬜ |  |
| 10: Angular ⭐ | 29–32 | 14 | ⬜ | ⬜ |  |
| 11: SignalR + MVC | 33 | 15 | ⬜ | ⬜ |  |
| 12: Deploy & DevOps | 34–35 | 16 | ⬜ | ⬜ |  |
| 13: Guided Project + Interviews | 36–38 | 17 | ⬜ | ⬜ |  |
| 14: YOUR Main Project 🏆 | solo | 18 | ⬜ | ⬜ | |

Start: Sunday 4 Oct 2026 → guided path ends around late June 2027 → then your solo main project.
