# Multi-Language System Project

## Overview
This project demonstrates a multi-language system that allows fetching available languages, setting the current language, and retrieving language-specific content via APIs.

## API Endpoints

- **Get All Languages**  
  `GET /api/admin/language`  
  Returns a list of all supported languages.

- **Set Current Language**  
  `POST /api/admin/language/set-language`  
  Example request body:   
  ```json
  {
    "language": "en-US"
  }

Sets the active language for the user, stored in cookies or session.

- **Get Products Based on Language**  
`GET /api/app/products`  
Returns product information based on the language specified in the request's cookies or headers.

## Usage Flow

1. Retrieve supported languages from `/api/admin/language`.
2. Set the desired language using `/api/admin/language/set-language`.
3. Fetch language-specific product data via `/api/app/products`.

---
