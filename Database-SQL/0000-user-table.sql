CREATE TABLE users (
    id INT PRIMARY KEY AUTO_INCREMENT,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(60) NOT NULL, -- BCrypt hashed password
    isActive BIT DEFAULT 1 -- 1 for active, 0 for inactive (you can adjust this based on your preference)
);

INSERT INTO users (email, password, isActive)
VALUES
    ('user1@example.com', '$2a$12$/RtKGgiGngmRV8zc2xHt/eihMV1dAkTyzpgU0GhGhPFyGNqdqJd7q', 1), -- isActive = 1 for active
    ('user2@example.com', '$2a$12$/ald/6L83Sg58UWicb9a4.NdtqJlGf4EKtlFOAgVrgLK9qqZbI5iu', 1);

