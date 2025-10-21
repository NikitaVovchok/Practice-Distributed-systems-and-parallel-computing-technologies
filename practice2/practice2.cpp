#include <iostream>
#include <mpi.h>

using namespace std;

int main(int argc, char** argv) {
    int mynode, totalnodes;
    MPI_Init(&argc, &argv);
    MPI_Comm_size(MPI_COMM_WORLD, &totalnodes);
    MPI_Comm_rank(MPI_COMM_WORLD, &mynode);

    // Вправа 1: Обчислення суми з вимірюванням часу
    int sum, startval, endval, accum;
    MPI_Status status;
    double start_time, end_time;

    start_time = MPI_Wtime();  // Початок вимірювання часу

    sum = 0;
    startval = 1000 * mynode / totalnodes + 1;
    endval = 1000 * (mynode + 1) / totalnodes;
    for (int i = startval; i <= endval; i++) {
        sum += i;
    }

    if (mynode != 0) {
        MPI_Send(&sum, 1, MPI_INT, 0, 1, MPI_COMM_WORLD);
    }
    else {
        for (int j = 1; j < totalnodes; j++) {
            MPI_Recv(&accum, 1, MPI_INT, j, 1, MPI_COMM_WORLD, &status);
            sum += accum;
        }
    }

    end_time = MPI_Wtime();  // Кінець вимірювання часу

    if (mynode == 0) {
        cout << "The sum from 1 to 1000 is: " << sum << endl;
        cout << "Execution time for sum: " << (end_time - start_time) << " seconds" << endl;
    }

    // Вправа 2: Передача буфера масиву
    const int buffer_size = 10;
    double buffer[buffer_size];

    // Заповнення буфера на кожному вузлі (приклад: значення на основі рангу)
    for (int i = 0; i < buffer_size; i++) {
        buffer[i] = mynode * 10.0 + i;
    }

    if (mynode != 0) {
        // Відправка буфера на вузол 0
        MPI_Send(buffer, buffer_size, MPI_DOUBLE, 0, 99, MPI_COMM_WORLD);
    }
    else {
        // Вузол 0: отримання від усіх інших і вивід
        cout << "Buffer transfers:" << endl;
        for (int j = 1; j < totalnodes; j++) {
            double recv_buffer[buffer_size];
            MPI_Recv(recv_buffer, buffer_size, MPI_DOUBLE, j, 99, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

            cout << "Received from node " << j << ": ";
            for (int k = 0; k < buffer_size; k++) {
                cout << recv_buffer[k] << " ";
            }
            cout << endl;
        }

        // Вивід власного буфера вузла 0
        cout << "My own buffer (node 0): ";
        for (int k = 0; k < buffer_size; k++) {
            cout << buffer[k] << " ";
        }
        cout << endl;
    }

    MPI_Finalize();
    return 0;
}