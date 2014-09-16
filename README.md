SimpleExpressionTree
====================

This is a simple expression tree example of searching entity by id for example.

Let's say you have an entity product table that you want to query based on the product id.

With regular non-generic Linq query, you probably do something like

var product = Product.FirstOrDefault(x => x.id == 1).


With this class, you can do it like

var product = EntityByExample<Product>.GetEntityByEntityId(yourDatabaseContextName, "1");


Please let me know if you have questions or suggestions.

Happy coding and enjoy!
