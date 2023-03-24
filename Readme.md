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


#### Docker Installation 

#### Kubernetes deployment configuration

