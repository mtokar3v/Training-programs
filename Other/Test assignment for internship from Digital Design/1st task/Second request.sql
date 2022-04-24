SELECT distinct d.ID, d.Name FROM Department AS d
INNER JOIN Employee ON d.ID =  
(SELECT distinct Departament_ID
FROM Employee
GROUP BY Departament_ID 
HAVING AVG(Salary) = 
(SELECT MAX(salary_avg) FROM(
SELECT Departament_ID ,AVG(Salary) as salary_avg
FROM Employee
GROUP BY Departament_ID) AS salary_avg)) 

