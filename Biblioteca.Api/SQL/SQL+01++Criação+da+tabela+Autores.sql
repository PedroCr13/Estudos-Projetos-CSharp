use biblioteca;

CREATE TABLE `autores` (
	`Id` int(11) NOT NULL,
        `Nome` longtext NOT NULL,
        `Email` longtext NOT NULL,
        `QuantidadeLivrosVendido` int(11),
	`ValorRecebido` decimal(18, 2),
        `Obervacao` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `autores`
	ADD PRIMARY KEY (`id`);
    
ALTER TABLE `autores`
	MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
    
ALTER TABLE `autores`
	MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;