GET
	URL: http://localhost:51748/api/values

POST
	URL: http://localhost:51748/api/values
	JSON:	
		{
			"lastName": "Ekedahl",

			"firstName": "Michael",
			"gpa": 3.5,

			"graduationDate": "2008-10-31T00:00:00-07:00",
			"active": false,
			"additionalValue": "I know how to make a RESTful API."

		}

PUT
	URL: http://localhost:51748/api/values/1
	JSON:
		{
        
			"lastName": "Rubio",

        		"firstName": "Steven",

        		"gpa": 3.9,

        		"graduationDate": "2017-10-31T00:00:00-07:00",

       		 "active": false,

       		 "additionalValue": "I know how to use Postman send different requests."

    		}

DELETE
	URL: http://localhost:51748/api/values/2