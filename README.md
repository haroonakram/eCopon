# eCopon
Trying to Make eCopon Competitions 


### REST API from scratch using .NET 6 


# Overview

In the Project, I build a CRUD REST API from scratch using .NET 6.
The backend system supports Creating, Reading, Updating and Deleting Competitions.
The backend system supports Creating, Reading, Updating and Deleting Winners.
... more sections are coming in the coming days


# API Definition

## Competition

### Create Competition Request

```js
POST /competition
```

```json
{
    "name": "Participate and enjoy the match between Saudi and UAE",
    "description": "The purchase condition is not required to enter the competition. The following categories are not allowed to participate in the competition, in order to achieve transparency, and they are: All members of the Jeddah Chamber of Commerce and their families.",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T08:00:00",
    "numberofwinners": "120",
    "numberofwithdraws": "330"
}
```



## Get Competition

### Get Competition Request

```js
GET /competition/{{id}}
```


### Get Competition Response

```js
200 Ok
```

```json
{
    
}
```

## Update Competition

### Update Competition Request

```js
PUT /competition/{{id}}
```


## Delete Competition

### Delete Competition Request

```js
DELETE /competition/{{id}}
```

### Delete Competition Response

```js
204 No Content
```

