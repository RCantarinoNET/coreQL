# coreQL
GraphQL + UI PlayGround + Core 



Getall

{
  owners
  {
    id,
    name,
    address
  }
}

--------------------------
Create
mutation($owner : ownerInput!){
  createOwner(owner:$owner)
  {
    id, name, address
  }
}
Query variable

{
  "owner": {
    "name": "teste renato",
    "address": "Aguas claras"
  }
}
------------------------------
Update
mutation($owner : ownerInput! , $id: ID!){
  updateOwner(owner:$owner , id:$id)
  {
    id, name, address
  }
}

{
  "owner": {
    "name": "update renato",
    "address": "update claras"
  },
  "id": "5df99a76-3af7-4d04-a936-5219eed2ba73"
}
------------------------------------
Delete

mutation($ownerId: ID!){
  deleteOwner(ownerId:$ownerId)
}
Query variable
{
  "ownerId": "5df99a76-3af7-4d04-a936-5219eed2ba73"
}
