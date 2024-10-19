## Commands

### Create Image

```bash
docker build -t minimalapi:v0.0.1  .
```

### Verify Image and Run Containerdocker logs minimalapi

```bash
docker images ls

docker run --name minimalapi -d -p 8080:8080 minimalapi:v0.0.1
```

### Verify Containers

```bash
docker ps
```

### Verify API

#### API with GET
```bash
curl http://localhost:8080/todoitems
```

#### API with POST

```bash
curl -X POST -H "Content-Type: application/json" -d "{\"name\": \"Learning Python\", \"isCompleted\": true}" http://localhost:8080/todoitems

curl http://localhost:8080/todoitems
```

#### API with PUT

```bash
curl -X PUT -H "Content-Type: application/json" -d "{\"name\": \"Learning Python\", \"isCompleted\": false}" http://localhost:8080/todoitems/1

curl http://localhost:8080/todoitems
```

#### API with DELETE

```bash
curl -X DELETE http://localhost:8080/todoitems/1
```

### Verify Logs

```bash 
docker logs minimalapi
```

### Stop Container

```bash
docker stop minimalapi
```

### Remove Container
```bash
docker rm minimalapi
```

### Remove Image

```bash
docker rmi minimalapi:v0.0.1
```

### Verify Network
```bash
docker network ls
```