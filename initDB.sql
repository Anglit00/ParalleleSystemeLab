-- initDB.sql
CREATE TABLE IF NOT EXISTS public.food
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    dangerlevel INTEGER NOT NULL,
    moreinfo TEXT,
    CONSTRAINT food_pkey PRIMARY KEY (id)
);
