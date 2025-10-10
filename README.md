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
- **Frontend:** Angular
- **Styling:** Angular Material  
- **Database:** Postgresql
- **Testing Framework:** xUnit + Moq (for TDD)  

### 3.2 Database Schema
**Movies Table**

| Field       | Type        | Notes                                |
|-------------|-------------|--------------------------------------|
| id          | Integer (PK)| Auto-increment                       |
| title       | String      | Movie name (required)                |
| description | Text        | Auto-fetched from API                |
| rating      | Float       | IMDb rating                          |
| cast        | Text/JSON   | List of main actors                  |
| priority    | Enum/Integer| 1=High, 2=Medium, 3=Low              |
| status      | Enum/String | “to_watch” or “seen”                 |
| date_added  | DateTime    | Default: now()                       |
| date_seen   | DateTime    | Null if not seen                     |

###
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
