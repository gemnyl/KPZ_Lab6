CREATE TABLE Player (
    id INT IDENTITY(1,1) NOT NULL,
    name NVARCHAR(255) NOT NULL UNIQUE,
    CONSTRAINT player_pkey PRIMARY KEY (id)
);
CREATE TABLE Highscore (
    highscore_id INT IDENTITY(1,1) NOT NULL,
    score INT,
    player_id INT,
    difficulty NVARCHAR(255),
    CONSTRAINT highscore_pkey PRIMARY KEY (highscore_id),
    CONSTRAINT highscore_player_id_fkey FOREIGN KEY (player_id) REFERENCES Player(id)
);
