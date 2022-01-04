﻿/*_577*/

select e.name, b.bonus from Employee as e
left join Bonus as b
on e.empId = b.empId
where b.bonus is null or b.bonus < 1000