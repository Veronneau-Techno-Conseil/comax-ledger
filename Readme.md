#### Comax ledger project
The aim of this project is to implement a custom smart contract. This project implemented by Sawtooth framework. Hyperledger Sawtooth is an enterprise solution for building, deploying, and running distributed ledgers (also called blockchains). It provides an extremely modular and flexible platform for implementing transaction-based updates to shared state between untrusted parties coordinated by consensus algorithms.



#### Run the project
1. ComaxLedgerApi: This project is responsible to submit a block into blockchain network.
2. ComaxProcessor: This project is responsible to handle transactions. If the transaction is without issue the status of the block will be committed, otherwise, it will be pending. 


#### ComaxLedgerApi
###### Transaction request are http request. The content type of request should be *application/octet-stream*. Each transaction has it's own sign algorithm. 

- BatcherPublicKey
- SignerPublickey
- FamilyName
- FamilyVersion

#### ComaxProcessor
This project is responsible for processing transaction. 



#### Protobuf Serilization
The neutral language used by Protobuf allows you to model messages in a structured format through .proto files:
```protobuf
message Person {
  required string name = 1;
  required int32 age = 2;
  optional string email = 3;
}
```
In the example above we use a structure that represents a person’s information, where it has mandatory attributes, such as name and age, as well as having the optional email data. Mandatory fields, as the name already says, must be filled when a new message is constructed, otherwise, a runtime error will occur.



#### Docker Installation 

#### Kubernetes deployment configuration

![image](https://user-images.githubusercontent.com/17474030/227582485-8c3671b0-a606-4e02-8b3e-8f365048de36.png)

All k8s files are located in this address: https://github.com/Veronneau-Techno-Conseil/comax-ledger/tree/main/src/k8s

Each node in this Sawtooth network runs a validator, a REST API, a consensus engine, and the following transaction processors:

Settings (settings-tp): Handles Sawtooth's on-chain configuration settings. The Settings transaction processor (or an equivalent) is required for all Sawtooth networks.


##### Important
Each node in a Sawtooth network must run the same set of transaction processors.




