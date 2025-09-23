# Movies-to-watch-app

## 1. Project Overview
The **Movies to Watch** app is a family-oriented web application designed to simplify choosing a movie for family movie night.  
The app enables users to maintain a curated list of movies, track watched titles, and enrich entries with details (fetched automatically from IMDb or a movie API).

**Motivation:** Families often spend excessive time (≈30 minutes) deciding what to watch. This app centralizes decision-making and adds structure to the process.

---

## 2. Core Features

### 2.1 Movie Lists
- **To Watch List:** Displays all pending movies with:
  - Title
  - Priority (High/Medium/Low)
  - Date added
  - IMDb rating
  - Short description
- **Seen Movies List:** Displays all watched movies with the date watched.

### 2.2 Movie Management
- Add a new movie:
  - Input: Movie name, priority, (optional) notes.
  - Auto-fetch details (via IMDb/TMDb/OMDb API):
    - Description
    - IMDb rating
    - Cast/crew
    - Poster image
- Edit movie details (priority, notes, etc.).
- Delete movie entries.

### 2.3 Movie Status
- Mark a movie as **“Seen”**.
- Automatically move from “To Watch” → “Seen Movies”.

### 2.4 IMDb Integration
- Use **OMDb API** (IMDb-compatible, free tier available).
- If not available, search for other API.
---

## 3. Technical Specification

### 3.1 Tech Stack
- **Backend:** C# with ASP.NET Core MVC  
- **Frontend:** Razor pages (or Blazor if preferred), HTML5, CSS3, JavaScript  
- **Styling:** Bootstrap/Tailwind for responsive web design  
- **Database:** SQL Server (local) or PostgreSQL/MySQL alternative  
- **ORM:** Entity Framework Core  
- **Testing Framework:** xUnit or NUnit + Moq (for TDD)  

### 3.2 Development Approach
- **Test-Driven Development (TDD):**
  1. Write unit tests for models, services, and controllers.  
  2. Write integration tests for API/movie fetching.  
  3. Ensure UI logic is tested with automated functional tests (e.g., Selenium or Playwright).  

### 3.3 Database Schema
**Movies Table**

| Field       | Type        | Notes                                |
|-------------|-------------|--------------------------------------|
| id          | Integer (PK)| Auto-increment                       |
| title       | String      | Movie name (required)                |
| description | Text        | Auto-fetched from API                |
| rating      | Float       | IMDb rating                          |
| cast        | Text/JSON   | List of main actors                  |
| poster_url  | String      | Link to poster image                 |
| priority    | Enum/Integer| 1=High, 2=Medium, 3=Low              |
| status      | Enum/String | “to_watch” or “seen”                 |
| date_added  | DateTime    | Default: now()                       |
| date_seen   | DateTime    | Null if not seen                     |

---

## 4. User Interface Specification

### 4.1 Pages
1. **Home (Dashboard)**  
   - Two sections: *To Watch* and *Seen*.  
   - Quick action buttons: “Mark as Seen”, “Delete”, “Edit”.  
   - Responsive grid layout for mobile/tablet/desktop.  

2. **Add Movie Page**  
   - Input: movie name, priority.  
   - Button: “Fetch details from IMDb”.  
   - Auto-populated fields: description, rating, cast, poster.  
   - Save to list.  

3. **Movie Detail Page**  
   - Full description, rating, cast, poster.  
   - Action buttons: Edit, Mark as Seen, Delete.  

4. **Seen Movies Page**  
   - List of watched movies with dates.  

### 4.2 UI/UX Requirements
- **Responsive Web Design:** Must work seamlessly across desktop, tablet, and mobile.  
- Clear visual separation between “To Watch” and “Seen”.  
- Priority color-coding:  
  - High = Red highlight  
  - Medium = Yellow  
  - Low = Green  

---

## 5. Non-Functional Requirements
- **Usability:** Intuitive, minimal clicks to add or mark a movie.  
- **Performance:** Movie detail fetch < 5s.  
- **Persistence:** Movies stored in relational database.  
- **Maintainability:** Follow MVC pattern with clean architecture.  
- **Testing:** All features validated via TDD before implementation.  
- **Security:** Input validation, CSRF protection, safe API requests.  

---

## 6. Development Plan (Milestones)

1. **MVP (Weeks 1–2)**  
   - ASP.NET Core MVC setup  
   - Movies CRUD (Create, Read, Update, Delete)  
   - To Watch and Seen lists  
   - Basic responsive design  

2. **Integration (Weeks 3–4)**  
   - OMDb API integration for movie details  
   - Unit + integration tests for API service  

3. **UI Improvements (Weeks 5–6)**  
   - Fully responsive layout with Bootstrap/Tailwind  
   - Priority highlighting  
   - Dedicated Movie Detail page  

4. **Testing & Polish (Weeks 7–8)**  
   - Full TDD coverage (unit + integration + UI tests)  
   - Optimize performance and responsiveness  
   - Family testing + feedback  

---
