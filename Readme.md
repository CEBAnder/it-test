# �������� ������� ��� �������� "���������������� ����������"
## ���������� �������
- it-test-producer - ������, ����������� ������ ������������ �� HTTP � ������������ �� � ���������
- it-test-consumer - ������, �������� ������ � ���� � �������� �� � ��. ��������� ��������� ������������ � �������� � �������������� ������ �������������
- it-test-consumer.Data - ������ ��� ������ � ��
- it-test-shared-contracts - ������, ������� ������������ ��� � ����������, ��� � � ����������
- it-test-producer.tests - ����-����� ����������
- it-test-consumer.tests - ����-����� ����������

## ������� ������ �������
`docker-compose up`
## ������� �������
### ���������� ������������
`curl --location --request POST 'https://localhost:5001/user' \
--header 'Content-Type: application/json' \
--data-raw '{
  "name": "Vsevolod",
  "surname": "Parshin",
  "patronymic": "Igorevich",
  "phoneNumber": "1234567890",
  "email": "test@ya.ru"
}'`
### ���������� ������������ � ������������
`curl --location --request POST 'https://localhost:5003/common/bind-org-user' \
--header 'Content-Type: application/json' \
--data-raw '{
    "UserId": 1,
    "OrgId": 1
}'`
### ��������� ������ �������������
`curl --location --request GET 'https://localhost:5003/common/users?PageSize=1&PageNumber=4'`