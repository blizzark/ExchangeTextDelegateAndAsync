# ExchangeTextDelegateAndAsync

Накосячил с названием...
Не text, а test.
Создавал обменник валют, чтобы потестить работу делегатов и потоков. 
--------------
Столкнулся с проблемой:
В методе, который лежит в делегате, есть обращение к элементам WinForms. Делегат вызывается в фоновом потоке. Происходит конфликт, так как вызывается метод, который был создан в другом потоке.

Текст ошибки: попытка доступа к элементу управления 'listBoxPriceBuyEuro' не из того потока, в котором он был создан.
--------------
Решил так: создал делегат для отслеживания из какого потока вызван метод (элемент)
