/*_1294*/

select 
c.country_name,
CASE
    WHEN temp.weather_state <= 15 THEN 'Cold'
WHEN temp.weather_state >= 25 THEN 'Hot'
ELSE 'Warm'
END as weather_type
from Countries as c
    join (select w.country_id, round(avg(cast(w.weather_state AS FLOAT)), 3) as weather_state from Weather as w
    where w.day >= '2019-11-01' and w.day < '2019-12-01'
group by w.country_id) as temp
    on c.country_id = temp.country_id