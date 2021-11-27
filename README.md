# Rocket_Elevators_REST_API

In order to connect our information system to the equipment in operation throughout the territory served, we developed a REST API using C # and .NET Core to allow us to know and to manipulate the status of all the relevant entities of the operational database.

NOTE: for PATCH, update status (or any single field) using the following format:
                 [{"op": "replace", "path": "/status", "value": "Offline"}]

## Batteries Controller

### Retrieve the current status of a specific Battery
```[HttpGet("{id}/status")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/batteries/10/status)

### Change the status of a specific Battery
```[HttpPatch("{id}")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/batteries/10)

## Columns Controller

### Retrieve the current status of a specific Column
```[HttpGet("{id}/status")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/columns/10/status)

### Change the status of a specific Column
```[HttpPatch("{id}")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/columns/10)
           
## Elevators Controller

### Retrieve the current status of a specific Elevator
```[HttpGet("{id}/status")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/elevators/10/status)

### Retrieve a list of Elevators that are not in operation at the time of the request
```[HttpGet("offline")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/elevators/offline)

### Change the status of a specific Elevator
``` [HttpPatch("{id}")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/columns/10)

## Buildings Controller

### Retrieve a list of Buildings that contain at least one battery, column or elevator requiring intervention
```[HttpGet("intervention")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/buildings/intervention)

### Retrieve customer information and the list of interventions that took place for a specific building
```[HttpGet("{id}/bonus2")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/buildings/5/bonus2)

## Leads Controller

### Retrieve a list of Leads created in the last 30 days who have not yet become customers
```[HttpGet("potentia l")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/leads/potential)

## FactInterventionsController

### Retrieve the address of the building, the beginning and the end of the intervention for a specific intervention.
```[HttpGet("{id}/bonus1")]```
[Example](https://codeboxx-week-8-rest-api.azurewebsites.net/api/factinterventions/5/bonus1)
