# Время жизни объектов и garbage collector

#### Какое максимальное поколение объектов в ходе выполнение программы было выявлено? Сколько их в C# всего?

>Объект myGCCol был создан при выполнении метода Main(), и, соответственно,
он не покидал область видимости до момента завершения программы, поэтому после
двух пережитых сборок мусора, поколение этого объекта увеличилось с 0 до 2.
Т.е. максимальное выявленное поколение - это второе поколение.

>Для оптимизации производительности сборщика мусора управляемая куча делится на три поколения: 0, 1 и 2.
Следовательно, объекты с большим и небольшим временем жизни обрабатываются отдельно.
Сборщик мусора хранит новые объекты в поколении 0. Уровень объектов, созданных на раннем этапе работы
приложения и оставшихся после сборок мусора, повышается, и они сохраняются в поколении 1 и 2.

#### Что будет если закомментировать строчку GC.Collect(0);? Изменится ли вывод программы, если да, то как и почему?

>Если закомментировать эту строку, тогда сборщик мусора не станет отчищать память неиспользуемых объектов 0-го поколения: 
1000 объектов класса Version, поэтому память в управляемой куче будет занята до тех пор, пока не вызовется 
очередная сборка мусора GC.Collect(2); ,а поколение объектов соответственно не увеличится, так как стало на одну чистку меньше. 
Таким образом изменится вывод программы: вывод количества занятой памяти будет
оставаться неизменным до последующего вызова сборщика мусора.

#### Что будет если закомментировать строчку GC.Collect(2);? Изменится ли вывод программы, если да, то как и почему?

>Если закомментировать эту строку, тогда сборщик мусора не станет отчищать память неиспользуемых объектов 0,1,2-го поколения, к тому же 
у объектов не увеличится номер поколения, так как стало на одну чистку меньше.

#### Измените параметр метода GC.GetTotalMemory() с true на false? На что это влияет?

>В данном случае булевый аргумент влияет на то, что нужно дожидаться выполнения сборки мусора при выводе общей занятой памяти(true) или нет(false)

#### В методе MakeSomeGarbage() добавьте к объекту vt создание еще одного любого объекта, например, класса StringBuilder. Что изменилось в выводе программы?

>В данном случае в управляемую кучу попадет еще больше значений, из-за чего займется больше памяти, которая освободится при первой же чистке,
так как это неиспользуемые объекты 0-го поколения.