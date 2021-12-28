--Create a SQL statement that will select the invoices that have more than three items and will also give
--us total price of every of such invoices.

SELECT i.Id, i.CustomerName, i.IssueDate, Count(i.Id) as count, SUM(ii.Price) as sum
FROM Invoice as i
INNER JOIN InvoiceItem as ii
ON i.Id = ii.InvoiceId 
GROUP BY i.Id, i.CustomerName, i.IssueDate
HAVING Count(i.Id) > 2