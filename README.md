# 🏋️‍♂️ Gym Store & Nutrition Management System

## 📌 Overview

This project is a full-featured ASP.NET Core MVC system that combines a gym store, nutrition management, and order processing system.

It allows users to browse gym equipment, nutritional products, build personal menus, manage a shopping cart, and complete orders.

Additionally, the system includes an admin (Manager) panel for full CRUD management of products, menus, and messages.

---

## ✨ Features

### 👤 User System
- User registration and login
- Personal cart per user
- Order history tracking
- User management (admin view)

---

### 🛒 Shopping System
- Add gym equipment to cart
- Add shakes & supplements
- Modify quantity in cart
- Remove items from cart
- Checkout and order completion

---

### 🏋️ Gym Equipment Management
- Add / Edit / Delete equipment
- Track stock availability
- Automatic stock reduction after order
- Low stock notifications

---

### 🥗 Nutrition & Food System
Supports multiple food categories:
- Meat (בשרי)
- Dairy (חלבי)
- Kosher / Parve
- Fruits, Vegetables, Bread
- Shakes & Supplements

Each item includes:
- Calories
- Carbs
- Protein
- Fats
- Description
- Image upload

---

### 📋 Menu System
- Create custom menus
- Add/remove food items
- Adjust quantities
- Automatic nutrition recalculation (calories, protein, fats, carbs)

---

### 📩 Messaging System
- System messages (stock alerts, orders)
- Mark messages as read/unread
- Filter read/unread messages
- Search messages by content or user

---

### 🔍 Search System
- Search gym equipment by name, category, brand
- Search shakes by taste/type
- Unified search results view

---

### 🧾 Order System
- Checkout process (`finishOrder`)
- Automatic stock updates
- Low stock alerts
- Order summary generation
- Save order history per user

---

### 🛠️ Admin Features (Manager Panel)
- Full CRUD for:
  - Equipment
  - Food items
  - Shakes & Supplements
- Menu creation and editing
- Message management
- User management

---

## 🧱 Architecture

Built using **ASP.NET Core MVC**
