#include <mpi.h>
#include <stdio.h>

int main(int argc, char** argv) {
    int rank, size;
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    // Task 1: Vector sum using Scatter and Reduce
    const int vector_size = 16;  // Must be divisible by size
    int subvector_size = vector_size / size;
    int vector[vector_size];
    int subvector[100];  // Buffer for subvector
    int partial_sum = 0;
    int total_sum = 0;

    if (rank == 0) {
        // Create vector: 1 to 16
        for (int i = 0; i < vector_size; i++) {
            vector[i] = i + 1;
        }
        printf("Task 1 - Full vector: ");
        for (int i = 0; i < vector_size; i++) {
            printf("%d ", vector[i]);
        }
        printf("\n");
    }

    // Scatter the vector
    MPI_Scatter(vector, subvector_size, MPI_INT, subvector, subvector_size, MPI_INT, 0, MPI_COMM_WORLD);

    // Compute partial sum
    for (int i = 0; i < subvector_size; i++) {
        partial_sum += subvector[i];
    }
    printf("Task 1 - Process %d: Partial sum = %d\n", rank, partial_sum);

    // Reduce to get total sum at root
    MPI_Reduce(&partial_sum, &total_sum, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (rank == 0) {
        printf("Task 1 - Total sum: %d\n", total_sum);
    }

    // Barrier to synchronize before Task 2
    MPI_Barrier(MPI_COMM_WORLD);

    // Task 2: Prefix sum using Scan
    int local_value = rank + 1;  // Each process has value based on rank (1,2,3,...)
    int prefix_sum = 0;

    // Compute prefix sum
    MPI_Scan(&local_value, &prefix_sum, 1, MPI_INT, MPI_SUM, MPI_COMM_WORLD);

    printf("Task 2 - Process %d: Local value = %d, Prefix sum = %d\n", rank, local_value, prefix_sum);

    MPI_Finalize();
    return 0;
}