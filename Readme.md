# Тестовое задание для компании "Интеллектуальные технологии"
## Содержимое проекта
- it-test-producer - сервис, принимающий данные пользователя по HTTP и отправляющий их в консьюмер
- it-test-consumer - сервис, читающий данные с шины и кладущий их в БД. Позволяет связывать пользователя и компанию и просматримвать список пользователей
- it-test-consumer.Data - классы для работы с БД
- it-test-shared-contracts - классы, которые используются как в продьюсере, так и в консьюмере
- it-test-producer.tests - юнит-тесты продьюсера
- it-test-consumer.tests - юнит-тесты консьюмера

## Быстрый запуск проекта
`docker-compose up`
## Примеры вызовов
### Добавление пользователя
`curl --location --request POST 'https://localhost:5001/user' \
--header 'Content-Type: application/json' \
--data-raw '{
  "name": "Vsevolod",
  "surname": "Parshin",
  "patronymic": "Igorevich",
  "phoneNumber": "1234567890",
  "email": "test@ya.ru"
}'`
### Связывание пользователя с организацией
`curl --location --request POST 'https://localhost:5003/common/bind-org-user' \
--header 'Content-Type: application/json' \
--data-raw '{
    "UserId": 1,
    "OrgId": 1
}'`
### Получение списка пользователей
`curl --location --request GET 'https://localhost:5003/common/users?PageSize=1&PageNumber=4'`