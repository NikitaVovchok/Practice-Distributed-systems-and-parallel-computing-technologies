#include <omp.h>
#include <stdio.h>

int main(int argc, char* argv[]) {
    // Завдання 1: Реалізація прикладів
    // Приклад: Таймер
    printf("--- Timer Example ---\n");
    double start_time, end_time, tick;
    start_time = omp_get_wtime();
    for (int i = 0; i < 1000000; i++); // Імітація роботи
    end_time = omp_get_wtime();
    tick = omp_get_wtick();
    printf("Duration: %lf seconds\n", end_time - start_time);
    printf("Precision: %lf seconds\n", tick);

    // Приклад: Serial/Parallel/Serial
    printf("--- Serial/Parallel Example ---\n");
    printf("Serial scope 1\n");
#pragma omp parallel num_threads(5)
    {
        printf("Parallel scope (thread %d)\n", omp_get_thread_num());
    }
    printf("Serial scope 2\n");

    // Приклад: Reduction
    printf("--- Reduction Example ---\n");
    int count = 0;
#pragma omp parallel num_threads(5) reduction(+:count)
    {
        count++;
        printf("count is %d (thread %d)\n", count, omp_get_thread_num());
    }
    printf("Total threads count: %d\n", count);

    // Завдання 2: Перевірка версії OpenMP
    printf("--- OpenMP Version ---\n");
#ifdef _OPENMP
    printf("OpenMP version: %d (YYYYMM, e.g., 201811 for 5.0)\n", _OPENMP);
#else
    printf("OpenMP is not supported by this compiler or not enabled.\n");
#endif

    // Завдання 3: Послідовна програма з OpenMP
    printf("--- Sequential Program with OpenMP ---\n");
    int sum = 0;
    for (int i = 1; i <= 100; i++) {
        sum += i;
    }
    printf("Sum: %d (executed by thread %d)\n", sum, omp_get_thread_num()); // Виконується 1 потік

    // Завдання 4: Коментар про структуру програми
    printf("--- Task 4 Comment ---\n");
    printf("A program cannot consist only of parallel regions (starts sequentially).\n");
    printf("It can consist only of sequential regions if no OpenMP directives are used.\n");

    // Завдання 5: Коментар про майстер-нитку
    printf("--- Task 5 Comment ---\n");
    printf("Master thread (thread 0) starts the program, creates other threads, and continues after parallel regions.\n");
    printf("Other threads exist only within parallel regions and are destroyed afterward.\n");

    return 0;
}