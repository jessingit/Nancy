The purpose of weather fetcher was to monitor locations temperature.

I had preset some location within a table to be monitored.

I was able to connect using the postgres library and a connection string port 5432

After the connect to the database, I used a select query to retrieve the names of the locations and initialised a list with the names

I looped through the names and for each name, I used a get request on the /track end poin on the weather.com API.

I used a c# framework called nancy to interface with weather.com API.

The result was returned as a JSON obj, I used the json newtonsoft framework to deserialise the JSON object.

With values obtained I then ran a SQL query which took the city name, localtime and temp.. then inserted this into another table within the RDS instance.
