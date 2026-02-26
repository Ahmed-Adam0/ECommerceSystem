# 🛒 E-Commerce Management System
> **Professional Onion Architecture Application using C# & EF Core**

---

## 📑 نبذة عن المشروع (Project Overview)
نظام متكامل لإدارة عمليات البيع والشراء، مصمم بمعمارية **Onion Architecture** لضمان أقصى درجات الفصل بين منطق الأعمال (Business Logic) وواجهة المستخدم. يتميز النظام بالاحترافية في التعامل مع البيانات واستخدام أنماط تصميم عالمية.



---

## 👥 فريق العمل (Team Members)

| الاسم 
| **Ahmed 

| **Sahar**|

| **Mayar

| **Mohammed**

| **Ayat** | 
---

## 🏗️ الهيكل الهندسي (System Architecture)

المشروع مبني على **4 طبقات منفصلة** لضمان سهولة الصيانة والتطوير:

### 1️⃣ Core Layer (Domain)
* تحتوي على الكيانات الأساسية (Entities).
* توصيف الجداول (Products, Categories, Users, Orders).

### 2️⃣ Application Layer
* **Interfaces**: تعريف العقود البرمجية.
* **DTOs**: كائنات نقل البيانات لضمان خصوصية الـ Database.
* **Services**: المحرك الأساسي لكل العمليات (Login, Register, CRUD).

### 3️⃣ Infrastructure Layer
* **DbContext**: المنسق مع SQL Server.
* **Generic Repository**: تنفيذ موحد لكل عمليات قاعدة البيانات.
* **Migrations**: سجل زمني لتطور قاعدة البيانات.

### 4️⃣ Presentation Layer (WinForms)
* واجهات تفاعلية تدعم الـ **Dependency Injection**.
* إدارة جلسات المستخدم (Session Management).

---

## 🛠️ الأدوات والتقنيات (Tech Stack)

* **Language:** C# (.NET 10.0)
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Dependency Injection:** Microsoft.Extensions.DependencyInjection
* **Version Control:** Git & GitHub

---

## ⚙️ تعليمات التشغيل (Setup Instructions)

لضمان تشغيل المشروع بنجاح، يرجى اتباع الآتي:

1.  **Clone & Pull**: اسحب آخر نسخة من برانش `dev`.
2.  **Restore Packages**: تأكد من تحميل كافة مكتبات الـ NuGet.
3.  **Database Update**: افتح الـ `Package Manager Console` واكتب:
    ```powershell
    Update-Database
    ```
4.  **Startup Project**: اجعل مشروع `ECommerce.Presentation.WinForms` هو المشروع الأساسي.

---

## 🛡️ ميزات الأمان والتنظيم
* **Authentication**: نظام تسجيل دخول مشفر وصلاحيات (Admin vs Customer).
* **Validation**: التحقق من البيانات قبل إرسالها لقاعدة البيانات.
* **Code Cleanliness**: فصل كامل للمسؤوليات (Separation of Concerns).

---
© 2026 E-Commerce System Project - Team Ahmed
