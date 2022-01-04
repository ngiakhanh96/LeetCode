/*_1251*/

select p.product_id, round(sum(p.price * u.units) * 1.0/sum(u.units), 2) as average_price from Prices as p
    join UnitsSold as u
on p.product_id = u.product_id
where u.purchase_date >= p.start_date and u.purchase_date <= p.end_date
group by p.product_id