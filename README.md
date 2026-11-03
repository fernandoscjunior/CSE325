# Prerequisites For this assignment

1 - in ContosoPizza/Services in PizzaServices I created the pepperoni pizza with ID 3

## 2 - Response to CRUD

### Response for GetAll

HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Mon, 02 Nov 2026 23:41:48 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Pepperoni",
    "isGlutenFree": false
  }
]

### Response for Get (by ID 2)

HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Mon, 02 Nov 2026 23:42:35 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "id": 2,
  "name": "Veggie",
  "isGlutenFree": true
}

### Response for Post (hawaii pizza)

HTTP/1.1 201 Created
Connection: close
Content-Type: application/json; charset=utf-8
Date: Mon, 02 Nov 2026 23:43:41 GMT
Server: Kestrel
Location: <http://localhost:5112/Pizza/4>
Transfer-Encoding: chunked

{
  "id": 4,
  "name": "Hawaii",
  "isGlutenFree": false
}

### Response for Put (update to hawaiian pizza)

HTTP/1.1 204 No Content
Connection: close
Date: Mon, 02 Nov 2026 23:45:44 GMT
Server: Kestrel

### Response for Delete (deleting pepperoni)

HTTP/1.1 204 No Content
Connection: close
Date: Mon, 02 Nov 2026 23:46:17 GMT
Server: Kestrel

---

## 3 - Sales report found in 'salesTotalDir/totals.txt'

Function:

void GenerateSalesReport()
{
    File.AppendAllText(Path.Combine(salesTotalDir, "report.txt"),
    $"Sales Summary{Environment.NewLine}----------------------{Environment.NewLine}Total Sales: ${salesTotal:F2}{Environment.NewLine}{Environment.NewLine}Details: {Environment.NewLine}");

    foreach (var file in salesFiles)
    {
        double eachSale = 0;
        string salesJson = File.ReadAllText(file);
        if (Path.GetFileName(file) == "salestotals.json")
        {
            TotalSalesData? data = JsonConvert.DeserializeObject<TotalSalesData?>(salesJson);
            eachSale += data?.OverallTotal ?? 0;
        }
        else
        {
            SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
            eachSale += data?.Total ?? 0;
        }
        File.AppendAllText(Path.Combine(salesTotalDir, "report.txt"), $"  {Path.GetFileName(file)}: ${eachSale:F2}{Environment.NewLine}");
    }
}
...

record TotalSalesData (double OverallTotal);

---

Output:

Sales Summary
----------------------
Total Sales: $2012,20

Details:
  sales.json: $88,88
  sales.json: $501,22
  salestotals.json: $1501,22
  sales.json: $1234,22
  salestotals.json: $101,22
  sales.json: $99,00
  salestotals.json: $154401,22
  sales.json: $88,88
  salestotals.json: $13501,22
