using Microsoft.EntityFrameworkCore;

namespace RecipesApp.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        UserID = 1,
                        UserName = "user1",
                        UserPW = "Password123!"
                    },
                    new User
                    {
                        UserID = 2,
                        UserName = "user2",
                        UserPW = "Password456?"
                    }
                    );
                context.SaveChanges();
            }

            if(!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        RecipeID = 1,
                        RecipeCategory = "American",
                        RecipeName = "Golden Apple Pie",
                        RecipeCreator = "user1",
                        RecipeRating = 4.5M,
                        RecipeIngredients = 
                        "6 cups sliced peeled Golden Delicious apples" +
                        "3/4 cup plus 2 tablespoons apple juice, divided" +
                        "3/4 cup sugar" +
                        "1 teaspoon ground cinnamon" +
                        "1/2 teaspoon apple pie spice" +
                        "2 tablespoons cornstarch" +
                        "1/4 teaspoon vanilla extract" +
                        "2-1/2 cups all-purpose flour" +
                        "1 teaspoon salt" +
                        "1 cup cold butter" +
                        "6 to 8 tablespoons ice water",
                        RecipeInstructions =
                        "1. In a large saucepan, combine apples, 3/4 cup apple juice, sugar, cinnamon and apple pie spice; bring to a boil over medium heat, stirring occasionally. Combine cornstarch and remaining apple juice; add to saucepan. Return to a boil, stirring constantly. Cook and stir 1 minute more or until thickened. Remove from the heat. Stir in vanilla. Cool to room temperature, stirring occasionally." +
                        "2. For crust, combine flour and salt; cut in the butter until mixture is crumbly. Gradually add water, 1 tablespoon at a time, tossing with a fork until dough can be formed into a ball. Divide in 2 portions, making 1 piece slightly larger. On a lightly floured surface, roll out larger portion." +
                        "3. Line a 9-in. pie plate with bottom crust; trim even with edge of plate. Add filling. Roll out remaining dough to fit top of pie; place over filling. Trim, seal and flute edges. Cut slits in top." +
                        "4. Bake at 400° for 40-45 minutes or until crust is golden brown and apples are tender. Cool on a wire rack."
                    },
                    new Recipe
                    {
                        RecipeID = 2, 
                        RecipeCategory = "Mexican", 
                        RecipeName = "Black bean and corn Nachos", 
                        RecipeCreator = "user1", 
                        RecipeRating = 4, 
                        RecipeIngredients =
                        "2 tbs extra virgin olive oil" +
                        "2 corn cobs, kernels sliced" +
                        "1 red onion, finely chopped" +
                        "1 red capsicum, seeds removed, chopped" +
                        "3 garlic cloves, crushed" +
                        "2 tsp each ground cumin & ground coriander" +
                        "1 bunch coriander, stalks thinly sliced, leaves picked" +
                        "2 chipotle chillies in adobo sauce" +
                        "1 bay leaf" +
                        "400g can chopped tomatoes" +
                        "2 x 400g cans black beans, rinsed, drained" +
                        "1 cup (250ml) vegetable stock" +
                        "170g corn chips" +
                        "200g coarsely grated cheddar" +
                        "2 ripe avocados, chopped" +
                        "Juice of 1 lime, plus extra wedges to serve" +
                        "Thinly sliced long green chillies, creme fraiche & Tabasco (optional), to serve", 
                        RecipeInstructions =
                        "1. Heat half the oil in a large frypan over high heat. Add corn kernels and cook, stirring occasionally, for 6 minutes or until golden. Set aside until needed." +
                        "2. Add remaining 1 tbs oil to pan. Add onion and capsicum, and cook, stirring occasionally, for 5 minutes or until softened. Add garlic, spices, coriander stalks, chipotle chillies and bay leaf, and cook, stirring occasionally, for 2 minutes or until fragrant. Add tomatoes and cook, breaking up with a wooden spoon, for 1 minute or until heated through. Stir through black beans and stock, bring to a simmer and cook, stirring occasionally, for 30 minutes or until thickened and reduced. Stir through corn kernels." +
                        "3. Preheat the oven to 180°C." +
                        "4. Spread corn chips over a baking tray and spoon over bean mixture. Sprinkle over cheese. Bake for 15 minutes or until cheese is golden and bubbling. Turn off oven, leaving tray in oven to keep nachos warm and melty until ready to serve." +
                        "5. Meanwhile, toss avocado and lime juice in a bowl with 1/2 tsp salt flakes." +
                        "6. Remove nachos from oven and scatter over chilli. Spoon over creme fraiche, top with coriander leaves and serve with lime wedges, Tabasco, if using, and avocado mixture alongside."
                    },
                    new Recipe
                    {
                        RecipeID = 3,
                        RecipeCategory = "Hawaiian",
                        RecipeName = "Ham and Cheese Sliders",
                        RecipeCreator = "user1",
                        RecipeRating = 2,
                        RecipeIngredients =
                        "12 dinner rolls" +
                        "12 slices ham" +
                        "8 ounces swiss cheese or cheddar cheese" +
                        "6 tablespoons butter melted, divided" +
                        "1 ½ teaspoons grainy mustard" +
                        "1 teaspoon Worcestershire sauce" +
                        "1 teaspoon poppy seeds" +
                        "1 teaspoon dried minced onion",
                        RecipeInstructions =
                        "1. Preheat oven to 350°F." +
                        "2. In a bowl combine 4 tablespoons butter, mustard, Worcestershire sauce, poppy seeds, and dried onion." +
                        "3. Cut the rolls in half separating the top and bottom. (If they are attached you don't need to separate each roll). Brush with the inside of the rolls remaining 2 tablespoons butter." +
                        "4. Place the bottom in a baking pan. Layer a slice of folded ham on each roll and top with the cheese." +
                        "5. Top with the other half of the roll and gently spoon the butter mixture overtop." +
                        "6. Bake uncovered about 20 minutes or until the cheese has melted and the tops are lightly browned. Serve warm."
                    },
                    new Recipe
                    {
                        RecipeID = 4,
                        RecipeCategory = "Chinese",
                        RecipeName = "Pork Dumplings",
                        RecipeCreator = "user1",
                        RecipeRating = 4.5M,
                        RecipeIngredients =
                        "100 (3.5 inch square) wonton wrappers" +
                        "1 ¾ pounds ground pork" +
                        "1 tablespoon minced fresh ginger root" +
                        "4 cloves garlic, minced" +
                        "2 tablespoons thinly sliced green onion" +
                        "4 tablespoons soy sauce" +
                        "3 tablespoons sesame oil" +
                        "1 egg, beaten" +
                        "5 cups finely shredded Chinese cabbage",
                        RecipeInstructions =
                        "1. In a large bowl, combine the pork, ginger, garlic, green onion, soy sauce, sesame oil, egg and cabbage. Stir until well mixed." +
                        "2. Place 1 heaping teaspoon of pork filling onto each wonton skin. Moisten edges with water and fold edges over to form a triangle shape. Roll edges slightly to seal in filling. Set dumplings aside on a lightly floured surface until ready to cook." +
                        "3. Arrange dumplings in a covered bamboo or metal steamer so they don't touch to prevent them from sticking together; steam for 15 minutes, or until pork is cooked through."
                    },
                    new Recipe
                    {
                        RecipeID = 5,
                        RecipeCategory = "Italian",
                        RecipeName = "Italian Sausage Lasagna",
                        RecipeCreator = "user1",
                        RecipeRating = 4.5M,
                        RecipeIngredients =
                        "1 pound Bob Evans Italian Roll Sausage" +
                        "1 jar pasta sauce (26 oz)" +
                        "1 can tomato sauce (15 oz)" +
                        "1 package oven ready lasagna noodles (8 oz)" +
                        "1 container ricotta cheese (15 oz)" +
                        "1 teaspoon Italian seasoning" +
                        "4 cups shredded mozzarella cheese" +
                        "1/2 cup grated Parmesan cheese",
                        RecipeInstructions =
                        "1. In a skillet, crumble and cook sausage over medium heat until brown." +
                        "2. Remove from heat and stir in pasta sauce and tomato sauce." +
                        "3. In small bowl, combine ricotta cheese and Italian seasoning." +
                        "4. Preheat oven to 375F." +
                        "5. Spread 1 cup sauce into bottom of a 9 x 13 inch baking dish. Top with 3 noodles." +
                        "6. Cover noodles with 1/3 of ricotta cheese mixture, 1 cup of mozzarella and 1 cup sauce. Repeat layers two more times. Add last 3 noodles." +
                        "7. Top lasagna with remaining sauce and with remaining mozzarella cheese. Sprinkle Parmesan over mozzarella." +
                        "8.Cover and bake 45 to 50 minutes or until noodles are tender. Uncover and bake an additional 5 minutes to melt cheese."
                    },
                    new Recipe
                    {
                        RecipeID = 6,
                        RecipeCategory = "French",
                        RecipeName = "Light and Airy Cheese Soufflé",
                        RecipeCreator = "user1",
                        RecipeRating = 5,
                        RecipeIngredients =
                        "1 1/2 tablespoons unsalted butter, plus extra for greasing ramekins" +
                        "2 tablespoons finely grated Parmesan cheese" +
                        "1 1/2 tablespoons all-purpose flour" +
                        "1/2 cup whole milk" +
                        "2 large eggs, separated" +
                        "1/2 teaspoon ground mustard" +
                        "1/4 teaspoon salt" +
                        "1/4 teaspoon white pepper" +
                        "1/4 to 1/3 cup grated cheese (any type)" +
                        "1/4 teaspoon cream of tartar",
                        RecipeInstructions =
                        "1. Grease 2 (1-cup) soufflé dishes/ramekins with butter and dust with Parmesan cheese" +
                        "2. Melt the butter over medium-low heat, then add flour and cook for 3 minutes, stirring constantly." +
                        "3. In the meantime, heat the milk in the microwave at medium power for 30 seconds just to warm." +
                        "4. Whisk warmed milk into the flour and butter mixture and continue to cook, stirring, until thickened." +
                        "5. Whisk together the egg yolks, ground mustard, salt, and white pepper, then add to sauce mixture, whisking quickly to avoid scrambling the eggs." +
                        "6. Stir in the grated cheese, melt and mix thoroughly." +
                        "7. Remove from heat and allow it to cool to room temperature, about 15 minutes. While the custard is cooling, preheat the oven to 425 F." +
                        "8. Beat the egg whites and cream of tartar to medium-stiff peaks using a hand mixer or standing mixer." +
                        "9. Once medium-stiff peaks form, fold 1/3 of the whites into the room-temperature sauce mixture." +
                        "10. Carefully and delicately fold this mixture back into the remaining whites until just combined." +
                        "11. Divide between the prepared soufflé dishes, place in the oven, reduce the heat to 375 F, and bake 30 to 35 minutes depending on how well done you like your soufflés. A toothpick inserted in the middle should come out mostly clean, with no wet batter attached. Don’t open the oven within the first 20 minutes or the soufflés will deflate." +
                        "12. Serve the soufflé immediately while hot."
                    }
                    );
            }

            if(!context.Discussions.Any())
            {
                context.Discussions.Add(
                    new Discussion
                    {
                        DiscussionID = 1,
                        DiscussionUser = "user2",
                        DiscussionPost = "This is the best apple pie I have ever had!",
                        DiscussionDate = DateTime.Now.ToString("HH:mm:ss tt")
                    }
                );
            }
        }
    }
}
