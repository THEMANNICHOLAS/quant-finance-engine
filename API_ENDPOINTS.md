# API Endpoints

Get a list of current or historical option expiration dates for an underlying symbol. If no optional parameters are used, the endpoint returns the expirations for strike in the chain.

## Parameters

format
string
(query)
The format parameter is used to specify the format for your data. We support JSON and CSV formats. The default format is JSON.

--
strike
string
(query)
Limit the lookup of expiration dates to the strike provide. This will cause the endpoint to only return expiration dates that include this strike.

strike
date
string($date)
(query)
Use to lookup a historical list of expiration dates from a specific previous trading day. If date is omitted the expiration dates will be from the current trading day during market hours or from the last trading day when the market is closed. Accepted date inputs: ISO 8601, unix, spreadsheet.

date
dateformat
string
(query)
The dateformat parameter allows you specify the format you wish to receive date and time information in.

--
limit
integer
(query)
The limit parameter allows you to limit the number of results for a particular API call or override an endpoint's default limits to get more data.

limit
offset
integer
(query)
The offset parameter is used together with limit to allow you to implement pagination in your application. Offset will allow you to return values starting at a certain value.

offset
headers
boolean
(query)
The headers parameter is used to turn off headers when using CSV output.

--
columns
string
(query)
The columns parameter is used to limit the results and only request the columns you need. The most common use of this feature is to embed a single numeric result from one of the end points in a spreadsheet cell.

columns
human
boolean
(query)
Use human-readable attribute names in the JSON or CSV output instead of the standard camelCase attribute names.

--
underlying *
string
(path)
The underlying ticker symbol for the options chain you wish to lookup. Ticker Formats: (TICKER, TICKER.EX, EXCHANGE:TICKER)
