```
"""
Пример использования многопоточности в Python с использованием модуля threading.

Программа демонстрирует работу с общими ресурсами в многопоточной среде, используя мьютекс для обеспечения эксклюзивного доступа к переменной shared_counter.

Для запуска программы необходимо выполнить следующую команду в командной строке: python readme.py

Требования к системе:
* Python версии не ниже 3.6.
* Модуль threading должен быть установлен.

Автор программы: [ваше имя или никнейм].
Дата создания: [дата создания файла].

Если у вас возникнут вопросы или предложения по улучшению программы, пожалуйста, свяжитесь со мной.

Спасибо за внимание!
"""

# Пример использования многопоточности и работы с общими ресурсами.
import threading
import time

shared_counter = 0  # Общая переменная для подсчёта количества инкрементов.
mutex = threading.Lock() # Мьютекс для управления доступом к shared_counter.

def increment_counter():
    global shared_counter
    mutex.acquire()
    try:
        shared_counter += 1
        print(f"Thread {threading.current_thread().name} incremented counter to {shared_counter}")
    finally:
        mutex.release()

threads = [] # Список потоков.
for i in range(3):
    thread = threading.Thread(target=increment_counter, name=f"Thread-{i}")
    threads.append(thread)

for thread in threads:
    thread.start() # Запуск потоков.

for thread in threads:
    thread.join() # Ожидание завершения всех потоков.

print("Final value of shared counter:", shared_counter) # Вывод конечного значения счётчика.
```