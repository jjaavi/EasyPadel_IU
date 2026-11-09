-- ============================================================
-- Script inicial de la base de dades de EASYPADEL
-- ============================================================

USE easy_padel;

-- Ordres per borrar les dades de prova
-- SET FOREIGN_KEY_CHECKS = 0;
-- TRUNCATE TABLE reserves;
-- TRUNCATE TABLE pistes;
-- TRUNCATE TABLE usuaris;
-- SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO usuaris (nom, cognom, email, password, telefon, rol) VALUES
('Marc',  'Garcia',  'marc.garcia@gmail.com',  '$2a$10$43dKSmm51yqfwqk9OqQNq.Wrswvg7uO36yWVhY8gVKr5ZYGyIlt6C', '648213759', 'USER'),
('Laura', 'Pons',    'laura.pons@gmail.com',   '$2a$10$43dKSmm51yqfwqk9OqQNq.Wrswvg7uO36yWVhY8gVKr5ZYGyIlt6C', '671934085', 'USER'),
('Javi',  'Sanchez',  'jjaavi@gmail.com',  '$2a$10$43dKSmm51yqfwqk9OqQNq.Wrswvg7uO36yWVhY8gVKr5ZYGyIlt6C', '657342891', 'ADMIN');

INSERT INTO pistes (nom, activa) VALUES
('Pista 1',  TRUE),
('Pista 2',  TRUE),
('Pista 3',  TRUE),
('Pista 4',  TRUE),
('Pista 5',  FALSE);

INSERT INTO reserves (usuari_id, pista_id, data, torn)
SELECT u.id, p.id, DATE_ADD(CURRENT_DATE, INTERVAL prova.dies DAY), prova.torn
FROM (
    SELECT 'marc.garcia@gmail.com' AS email, 'Pista 1' AS pista, -3 AS dies, 1 AS torn
    UNION ALL SELECT 'marc.garcia@gmail.com', 'Pista 2', 1, 3
    UNION ALL SELECT 'laura.pons@gmail.com', 'Pista 3', -2, 2
    UNION ALL SELECT 'laura.pons@gmail.com', 'Pista 4', 2, 4
    UNION ALL SELECT 'pau.serra@gmail.com', 'Pista 5', -1, 3
    UNION ALL SELECT 'pau.serra@gmail.com', 'Pista 6', 3, 5
    UNION ALL SELECT 'anna.vidal@gmail.com', 'Pista 7', 0, 4
    UNION ALL SELECT 'anna.vidal@gmail.com', 'Pista 8', 4, 6
    UNION ALL SELECT 'joan.ferrer@gmail.com', 'Pista 9', 0, 5
    UNION ALL SELECT 'joan.ferrer@gmail.com', 'Pista 1', 5, 7
) AS prova
JOIN usuaris u ON u.email = prova.email
JOIN pistes p ON p.nom = prova.pista;


-- ============================================================


