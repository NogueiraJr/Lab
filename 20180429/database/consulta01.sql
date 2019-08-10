select a.nomeCliente, d.nomeProduto, b.dtReserva, b.dtRetirada, b.dtDevolucao
from Clientes a
inner join Locacoes b on a.Clientes_id = b.Clientes_id
inner join LocacoesProdutos c on b.Locacoes_id = c.Locacoes_id
inner join Produtos d on c.Produtos_id = d.Produtos_id
where a.Clientes_id = 1 and b.Clientes_id = 1
order by 1, 2
;