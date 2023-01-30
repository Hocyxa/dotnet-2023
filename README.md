# Промышленное программирование
# Лабораторные работы - 2023

## Задание

### Цель
Реализация проекта клиент-серверного приложения.

### Задачи
* Реализация объектно-ориентированной модели данных
* Изучение реализации серверных приложений на базе WebAPI/OpenAPI
* Реализация клиентского приложения с использованием Avalonia 
* Изучение паттернов проектирования
* Повторение основ работы с системами контроля версий
* Unit-тестирование

### Лабораторные работы
1.	«Классы» - Реализация объектной модели данных
2.	«Сервер» - Реализация серверного приложения
3.	«ORM» - Реализация объектно-реляционной модели. Подключение к базе данных
4.	«Клиент» - Реализация клиентского приложения 

В рамках первой лабораторной работы необходимо подготовить структуру классов, описывающих предметную область, определяемую в задании. В каждом из заданий присутствует часть, связанная с обработкой данных, представленная в разделе «Запросы». Данную часть необходимо реализовать в виде unit-тестов: подготовить тестовые данные, выполнить запрос с использованием LINQ, проверить результаты.

Во второй лабораторной работе необходимо реализовать серверное приложение, которое должно:
- Осуществлять базовые CRUD-операции с реализованными в первой лабораторной сущностями
- Предоставлять результаты аналитических запросов (раздел «Запросы» задания)

Хранение данных осуществлять в памяти в виде коллекций.

В третьей лабораторной работе хранение данных должно быть переделано на базу данных. Необходимо использовать объектно-реляционную модель на базе EF Core с целевой СУБД MySQL. 

В четвертой лабораторной работе необходимо реализовать клиентское приложение с использованием Avalonia, которое будет взаимодействовать с реализованным серверным приложением.

## Задание. Общая часть

**Обязательно**:
* Реализация как серверной, так и клиентской части системы
* Реализация серверной части на .NET 6
* Реализация серверной части на ASP.NET 
* Реализация unit-тестов с использованием xUnit
* Использование хранения данных в базе данных. По умолчанию MySQL
* Создание минимальной документации к проекту: страница на GitHub с информацией о задании, скриншоты приложения и прочая информация

**Факультативно**:
* Автоматизация тестирования на уровне репозитория через [GitHub Actions](https://docs.github.com/en/actions/learn-github-actions/understanding-github-actions)
* Интеграционное тестирование
* Использование иной СУБД (не MySQL)
* Свой вариант задания
* Реализация авторизации/аутентификации

## Варианты заданий

Номер задания соответствуют вашему номеру в списке групп. 
Задания соответствуют 3 лабораторной работе по курсу [«Базы данных»](https://github.com/itsecd/databases/blob/main/labs/%D0%9B%D0%A03.%20%D0%9F%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5%20%D0%91%D0%94.pdf)

Если вы учитесь на 5 курсе, то вам необходимо согласовать вариант задания с преподавателем, который ведет у вас лабораторные работы.

Если вас не устраивает ваш вариант задания, необходимо сообщить об этом преподавателю и согласовать индивидуальный вариант.

## Схема сдачи

На каждую из лабораторных работ необходимо сделать отдельный Pull Request (PR).

Общая схема:
1. Сделать форк данного репозитория
2. Выполнить задание
3. Сделать PR в данный репозиторий
4. Исправить замечания после code review
5. Получить approve 
6. Прийти на занятие и защитить работу

## Критерии оценивания

Конкурентный принцип.
Так как задания в первой лабораторной будут повторяться между студентами, то выделяются следующие показатели для оценки:
1. Скорость разработки
2. Качество разработки
3. Полнота выполнения задания

Быстрее делаете PR - у вас преимущество.
Быстрее получаете Approve - у вас преимущество.
Выполните нечто немного выходящее за рамки проекта - у вас преимущество перед остальными.

### Шкала оценивания

- **3 балла** за качество кода, из них:
  - 2 балла - базовая оценка
  - 1 балл (но не более) можно получить за выполнение любого из следующих пунктов:
    - Реализация факультативного функционала
    - Выполнение работы раньше других: первые 5 человек из каждой группы, которые сделали PR и получили approve, получают дополнительный балл
- **3 балла** за защиту: при сдаче лабораторной работы вам задается 3 вопроса, за каждый правильный ответ - 1 балл

Плановый график сдачи лабораторных работ (дата получения аппрува на присланный PR):
- № 1: 15.03.2023
- № 2: 12.04.2023
- № 3: 10.05.2023
- № 4: 31.05.2023

При получении аппрува после плановой даты количество получаемых баллов уменьшается на 1.

Итого за каждую лабораторную работу можно получить максимум в 6 баллов, итого 24 балла (за 4 лабораторные).

Для допуска к экзамену за все лабы суммарно нужно набрать не менее 10 баллов из 24.
