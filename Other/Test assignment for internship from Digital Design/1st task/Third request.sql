SELECT distinct d.ID, d.Name FROM Department AS d
INNER JOIN Employee ON d.ID =
(SELECT Departament_ID FROM Employee
GROUP BY Departament_ID
HAVING SUM(Salary) = 
(SELECT MAX(salary_sum) FROM(
SELECT Departament_ID ,SUM(Salary) as salary_sum
FROM Employee
GROUP BY Departament_ID) AS salary_sum)) 