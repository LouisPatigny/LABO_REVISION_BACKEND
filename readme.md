CREATE TABLE "users" (
    "id" serial PRIMARY KEY,
    "email" varchar UNIQUE NOT NULL,
    "password" varchar NOT NULL,
    "created_at" timestamp DEFAULT (now())
);

CREATE TABLE "categories" (
    "id" serial PRIMARY KEY,
    "name" varchar UNIQUE NOT NULL,
    "created_at" timestamp DEFAULT (now())
);

CREATE TABLE "products" (
    "id" serial PRIMARY KEY,
    "name" varchar NOT NULL,
    "description" text,
    "price" numeric(10,2) NOT NULL,
    "stock" integer DEFAULT 0,
    "image_url" varchar,
    "created_at" timestamp DEFAULT (now()),
    "deleted_at" timestamp DEFAULT NULL, -- Soft delete column
    "status" varchar DEFAULT 'active',  -- e.g., active/inactive
    "category_id" integer
);

CREATE TABLE "shipping_addresses" (
    "id" serial PRIMARY KEY,
    "first_name" varchar NOT NULL,
    "last_name" varchar NOT NULL,
    "address_line1" varchar NOT NULL,
    "address_line2" varchar,
    "city" varchar NOT NULL,
    "postal_code" varchar NOT NULL,
    "country" varchar NOT NULL,
    "phone_number" varchar,
    "created_at" timestamp DEFAULT (now())
);

CREATE TABLE "orders" (
    "id" serial PRIMARY KEY,
    "email" varchar NOT NULL, -- Guest’s email
    "order_date" timestamp DEFAULT (now()),
    "status" varchar DEFAULT 'pending', -- e.g., 'pending', 'paid', 'shipped'
    "total_amount" numeric(10,2) NOT NULL DEFAULT 0,
    "shipping_address_id" integer
    -- "payment_method" varchar,
    -- "payment_status" varchar,
    -- "transaction_id" varchar
);

CREATE TABLE "order_items" (
    "id" serial PRIMARY KEY,
    "order_id" integer NOT NULL,
    "product_id" integer NOT NULL,
    "quantity" integer NOT NULL DEFAULT 1,
    "unit_price" numeric(10,2) NOT NULL,
    "created_at" timestamp DEFAULT (now())
);

ALTER TABLE "products" ADD FOREIGN KEY ("category_id") REFERENCES "categories" ("id");

ALTER TABLE "orders" ADD FOREIGN KEY ("shipping_address_id") REFERENCES "shipping_addresses" ("id");

ALTER TABLE "order_items" ADD FOREIGN KEY ("order_id") REFERENCES "orders" ("id");

ALTER TABLE "order_items" ADD FOREIGN KEY ("product_id") REFERENCES "products" ("id");


------------------------------------------


-- 1) Insert the sole admin user
INSERT INTO "users" ("email", "password")
VALUES
    ('user@gmail.com', 'someHashedPassword'),
    ('user2@gmail.com', 'someHashedPassword2');

-- 2) Insert categories (T-Shirt, Sweater, Cap)
INSERT INTO "categories" ("name")
VALUES
    ('T-Shirt'),
    ('Sweater'),
    ('Cap');

-- 3) Insert products (6 total, including inactive and deleted products)
INSERT INTO "products" ("name", "description", "price", "stock", "image_url", "status", "deleted_at", "category_id")
VALUES
    -- Active products
('Black T-Shirt', 'A stylish black tee with POST-APO vol.2 design', 19.99, 50, '/images/black_tshirt.jpg', 'active', NULL, 1),
('White T-Shirt', 'A crisp white tee featuring the artist logo', 19.99, 30, '/images/white_tshirt.jpg', 'active', NULL, 1),
('Black Sweater', 'Warm black sweater for the post-apocalyptic vibe', 29.99, 40, '/images/black_sweater.jpg', 'active', NULL, 2),

    -- Inactive products
    ('White Sweater', 'Cozy white sweater with an embroidered design', 29.99, 20, 'img/white_sweater.jpg', 'inactive', NULL, 2),

    -- Soft-deleted products
    ('Black Cap', 'Classic black cap with Futur Bandit logo', 14.99, 25, 'img/black_cap.jpg', 'inactive', '2024-01-01 10:00:00', 3),
    ('White Cap', 'Stylish white cap with an embroidered motif', 14.99, 15, 'img/white_cap.jpg', 'inactive', '2024-01-02 15:00:00', 3);

-- 4) Insert shipping addresses
INSERT INTO "shipping_addresses"
("first_name", "last_name", "address_line1", "address_line2", "city", "postal_code", "country", "phone_number")
VALUES
    ('Alice', 'Dupont', '123 Dystopia Lane', 'Apt 2B', 'Neo-Paris', '75001', 'France', '+33 6 12 34 56 78'),
    ('Bob', 'Martinez', '456 Apocalypse Blvd', NULL, 'London', 'EC1A 1BB', 'UK', '+44 20 1234 5678');

-- 5) Insert two orders (one for each shipping address)
INSERT INTO "orders"
("email", "status", "total_amount", "shipping_address_id")
VALUES
    ('alice@example.com', 'paid', 39.98, 1),
    ('bob@example.com', 'pending', 44.97, 2);

-- 6) Insert order_items
INSERT INTO "order_items"
("order_id", "product_id", "quantity", "unit_price")
VALUES
    (1, 1, 1, 19.99),
    (1, 2, 1, 19.99),
    (2, 3, 1, 29.99),
    (2, 5, 1, 14.99);
