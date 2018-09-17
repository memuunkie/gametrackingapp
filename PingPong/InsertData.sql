INSERT INTO Players VALUES ('Alcaide', 'Myrna', GETDATE());
INSERT INTO Players VALUES ('Pool', 'Dead', GETDATE());
INSERT INTO Players VALUES ('Rogers', 'Steve', GETDATE());
INSERT INTO Players VALUES ('Romanova', 'Natasha', GETDATE());
INSERT INTO Players VALUES ('Quill', 'Peter', GETDATE());
INSERT INTO Players VALUES ('Destroyer', 'Drax', GETDATE());

INSERT INTO Teams VALUES (1, 2, 'XForce', GETDATE());
INSERT INTO Teams VALUES (3, 4, 'Avengers', GETDATE());
INSERT INTO Teams VALUES (5, 6, 'Guardians', GETDATE());

INSERT INTO SingleGames VALUES (1, 2, 5, 3, GETDATE());
INSERT INTO SingleGames VALUES (2, 3, 4, 6, GETDATE());
INSERT INTO SingleGames VALUES (3, 4, 5, 7, GETDATE());
INSERT INTO SingleGames VALUES (4, 5, 5, 5, GETDATE());
INSERT INTO SingleGames VALUES (5, 6, 4, 5, GETDATE());
INSERT INTO SingleGames VALUES (6, 1, 6, 8, GETDATE());
INSERT INTO SingleGames VALUES (1, 3, 4, 8, GETDATE());
INSERT INTO SingleGames VALUES (2, 4, 3, 6, GETDATE());
INSERT INTO SingleGames VALUES (3, 5, 7, 5, GETDATE());
INSERT INTO SingleGames VALUES (4, 6, 5, 8, GETDATE());
INSERT INTO SingleGames VALUES (5, 1, 3, 8, GETDATE());
INSERT INTO SingleGames VALUES (6, 2, 7, 5, GETDATE());
INSERT INTO SingleGames VALUES (1, 4, 5, 5, GETDATE());
INSERT INTO SingleGames VALUES (2, 5, 6, 5, GETDATE());
INSERT INTO SingleGames VALUES (3, 6, 7, 4, GETDATE());
INSERT INTO SingleGames VALUES (1, 6, 6, 5, GETDATE());

INSERT INTO TeamGames VALUES (1, 2, 10, 11, GETDATE());
INSERT INTO TeamGames VALUES (1, 3, 15, 13, GETDATE());
INSERT INTO TeamGames VALUES (2, 3, 11, 13, GETDATE());
INSERT INTO TeamGames VALUES (2, 1, 14, 10, GETDATE());
INSERT INTO TeamGames VALUES (3, 1, 13, 10, GETDATE());
INSERT INTO TeamGames VALUES (3, 2, 10, 16, GETDATE());
INSERT INTO TeamGames VALUES (3, 1, 16, 12, GETDATE());
INSERT INTO TeamGames VALUES (2, 1, 14, 11, GETDATE());
INSERT INTO TeamGames VALUES (1, 2, 15, 10, GETDATE());
INSERT INTO TeamGames VALUES (1, 3, 13, 14, GETDATE());
INSERT INTO TeamGames VALUES (3, 2, 13, 14, GETDATE());
INSERT INTO TeamGames VALUES (2, 3, 13, 14, GETDATE());


SELECT * FROM Players;

SELECT * FROM Teams;

SELECT * FROM SingleGames;

SELECT * FROM TeamGames;

/*
DROP TABLE SingleGames;
DROP TABLE TeamGames;
DROP TABLE Teams;
DROP TABLE Players;
*/