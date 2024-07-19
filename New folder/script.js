$(document).ready(function() {
    // This function runs when the document is ready and ensures all HTML elements are loaded before executing JavaScript.

    // Ajax request to fetch book data from books.json
    $.ajax({
        url: 'books.json', // URL of the JSON file containing book data
        dataType: 'json', // Expected data type
        success: function(data) {
            // Function to display books in the table
            function displayBooks(books) {
                $('tbody').empty(); // Clear existing table rows before adding new ones
                books.forEach(function(book) {
                    // Append each book as a table row with its properties
                    $('tbody').append(
                        `<tr>
                            <td>${book.title}</td>
                            <td>${book.author}</td>
                            <td>${book.price}</td>
                            <td>${book.availability}</td>
                        </tr>`
                    );
                });
            }

            // Initial display of books when JSON data is successfully loaded
            displayBooks(data);

            // Search functionality
            $('#search-bar').on('input', function() {
                var query = $(this).val().toLowerCase(); // Get the value of the search input and convert to lowercase
                var filteredBooks = data.filter(function(book) {
                    // Filter books based on title or author matching the search query
                    return book.title.toLowerCase().includes(query) || book.author.toLowerCase().includes(query);
                });
                displayBooks(filteredBooks); // Display filtered books
            });

            // Load more books button (dummy functionality, adjust as needed)
            //$('#load-more-btn').click(function() {
                // This click event handler simulates loading more books with Ajax
                // Example:
                // $.ajax({
                //     url: 'more_books.json',
                //     dataType: 'json',
                //     success: function(moreBooks) {
                //         displayBooks(moreBooks);
                //     }
                // });
           // });
        },
        error: function(jqXHR, textStatus, errorThrown) {
            // Error handling if JSON data cannot be fetched
            console.log('Error fetching JSON data:', textStatus, errorThrown);
        }
    });
});
