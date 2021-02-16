using ADProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace ADProject.DbSeeder
{
    public class DbSeedData
    {
        private readonly ADProjContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        public DbSeedData(ADProjContext db, UserManager<ApplicationUser> _userManager)
        {
            this.db = db;
            this._userManager = _userManager;
        }

        public void Init()
        {
            AddRecipes();
            AddTags();
            AddGroups();
            AddUsers();

            // Use this version to test authentication
            AddUsersVer2();
            AddRecipesVer2();
            AddGroupsVer2();
        }

        protected void AddGroupsVer2()
        {
            ApplicationUser user1 = db.Users.FirstOrDefault(user => user.NormalizedUserName.Equals("AK"));
            ApplicationUser user2 = db.Users.FirstOrDefault(user => user.NormalizedUserName.Equals("HM"));

            List<UsersGroup> ug = new List<UsersGroup>();
            ug.Add(new UsersGroup
            {
                UserId = user1.Id,
                IsMod = true,
                User = user1
            });
            ug.Add(new UsersGroup
            {
                UserId = user2.Id,
                IsMod = false,
                User = user2
            });

            db.Groups.Add(new Group
            {
                GroupName = "Japanese Food Guide",
                GroupPhoto = "https://www.ampersandtravel.com/media/843058/header.jpg?mode=crop&width=1485",
                Description = "Recipes that orginated at Japan",
                DateCreated = new DateTime(2008, 5, 1, 8, 30, 52),
                IsPublished = true,
                UsersGroups = ug
            });

            db.SaveChanges();
        }

        protected void AddRecipesVer2()
        {
            ApplicationUser u1 = new ApplicationUser
            {
                FirstName = "Akai",
                LastName = "Haato",
                UserName = "ak",
                NormalizedUserName = "ak".ToUpper(),
                Email = "ak@email.com",
                NormalizedEmail = "ak@email.com".ToUpper(),
                IsAdmin = true,
            };

            u1.PasswordHash = _userManager.PasswordHasher.HashPassword(u1, "12345");
            u1.SecurityStamp = _userManager.CreateSecurityTokenAsync(u1).ToString();

            db.Users.Add(u1);
            db.SaveChanges();

            ApplicationUser user = db.Users.FirstOrDefault(user => user.NormalizedUserName.Equals("AK"));

            List<RecipeIngredient> recipeIngredientpancake = new List<RecipeIngredient>();


            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "unsweetened nut or coconut milk",
                Quantity = 1,
                UnitOfMeasurement = "cup"
            });

            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "apple cider vinegar",
                Quantity = .5,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "pumpkin puree",
                Quantity = .75,
                UnitOfMeasurement = "cup"
            });

            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "maple syrup",
                Quantity = 3,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "peanut butter",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "vanilla extract",
                Quantity = 1,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "buckwheat flour ",
                Quantity = 1,
                UnitOfMeasurement = "cup"
            });
            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "almond flour",
                Quantity = 2,
                UnitOfMeasurement = "tbsp"
            });
            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "baking powder",
                Quantity = 2,
                UnitOfMeasurement = "tbsp"
            });
            recipeIngredientpancake.Add(new RecipeIngredient
            {
                Ingredient = "nutmeg,salt,ginger- each",
                Quantity = 1,
                UnitOfMeasurement = "pinch"
            });

            List<RecipeStep> recipeStepspancake = new List<RecipeStep>();
            recipeStepspancake.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "Pour the cup of unsweetened milk and apple cider vinegar in a large bowl. Let it sit for 5 minutes.",
               
            });
            recipeStepspancake.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "Add the rest of the ingredients, in order, stirring in between the wet and dry ingredients to make sure they are evenly distributed--especially the peanut butter. ",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/10/pumpkin-peanut-butter-pancakes-healthy-vegan-1024x732.jpg"
            });
            recipeStepspancake.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "Heat the skillet to a medium-high heat. The higher the temperature, the higher the pancake will be, just make sure it doesn't burn! If it burns, it's too hot.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/10/pumpkin-peanut-butter-pancakes-dairy-free-egg-free-1024x678.jpg"
            });
            recipeStepspancake.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "Pour on skillet in desired shape and cook on both sides-spread out with a spoon if necessary. Repeat.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/10/pumpkin-peanut-butter-pancakes.jpg"
            });

            List<RecipeTag> recipeTagpancake = new List<RecipeTag>();

            recipeTagpancake.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "pancake",
                    Warning = ""
                }
            });
            recipeTagpancake.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "pumkin",
                    Warning = ""
                }
            });


            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "PUMPKIN PEANUT BUTTER PANCAKES",
                Description = "These are drool-worthy!",
                DateCreated = new DateTime(2019, 6, 3, 8, 30, 52),
                DurationInMins = 40,
                Calories = 500,
                IsPublished = true,
                MainMediaUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/10/pumpkin-peanut-butter-pancakes-buckwheat-gluten-free-1024x1024.jpg",
                RecipeIngredients = recipeIngredientpancake,
                RecipeSteps = recipeStepspancake,
                RecipeTags = recipeTagpancake
            });

            db.SaveChanges();



            List<RecipeIngredient> recipeIngredient3 = new List<RecipeIngredient>();


            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "Portobello Mushroom ",
                Quantity = 1,
                UnitOfMeasurement = "Mushroom"
            });

            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "Wright's hickory liquid smoke",
                Quantity = 3,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = " molasses (or more maple syrup, molasses adds darker notes)",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "Onion powder",
                Quantity = .25,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "chilli powder, garlic powder each",
                Quantity = 1,
                UnitOfMeasurement = "pinch"
            });

            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "clove",
                Quantity = 1,
                UnitOfMeasurement = "pinch"
            });

            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "whipped Mayo",
                Quantity = 3,
                UnitOfMeasurement = "tbsp"
            });
            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "bread",
                Quantity = 2,
                UnitOfMeasurement = "slices"
            });
            recipeIngredient3.Add(new RecipeIngredient
            {
                Ingredient = "tomato and lettuce chopped for topping",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            List<RecipeStep> recipeSteps3 = new List<RecipeStep>();
            recipeSteps3.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = ".Mix all of the ingredients for the portobello mushroom bacon except for the first ingredient (the mushrooms). Stir well and set aside.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/05/mushrooms-600x450.jpg"
            });
            recipeSteps3.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = " Lay the sliced mushrooms into a skillet and pour the bacon flavor mixture over the bacon. ",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/05/mushroom-bacon-600x450.jpg"
            });
            recipeSteps3.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "Cook on each side for 3-5 minutes until the mushrooms have cooked down to about half their original size or until the liquid has absorbed and browned on the mushrooms.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/05/vegan-bacon-600x450.jpg"
            });
            recipeSteps3.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "Thinly slice the tomato and layer the tomato and lettuce leaves on the bread. Then, top with bacon.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/05/bacon-lettuce-tomato-sandwich-vegan-1024x678.jpg"
            });

            List<RecipeTag> recipeTag3 = new List<RecipeTag>();

            recipeTag3.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Sandwich",
                    Warning = ""
                }
            });
            recipeTag3.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "mushroom bacon",
                    Warning = ""
                }
            });


            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "PORTOBELLO MUSHROOM VEGAN BLT SANDWICH",
                Description = "These are drool-worthy!",
                DateCreated = new DateTime(2018, 6, 3, 8, 30, 52),
                DurationInMins = 20,
                Calories = 300,
                IsPublished = true,
                MainMediaUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/05/vegan-blt-sandwich-1024x1024.jpg",
                RecipeIngredients = recipeIngredient3,
                RecipeSteps = recipeSteps3,
                RecipeTags = recipeTag3
            });

            db.SaveChanges();
        }

        protected void AddUsersVer2()
        {
            ApplicationUser u2 = new ApplicationUser
            {
                FirstName = "Amelia",
                LastName = "Watson",
                UserName = "aw",
                NormalizedUserName = "aw".ToUpper(),
                Email = "aw@email.com",
                NormalizedEmail = "aw@email.com".ToUpper(),
                IsAdmin = true,
            };

            u2.PasswordHash = _userManager.PasswordHasher.HashPassword(u2, "12345");
            u2.SecurityStamp = _userManager.CreateSecurityTokenAsync(u2).ToString();
            db.Users.Add(u2);

            ApplicationUser u3 = new ApplicationUser
            {
                FirstName = "Honshou",
                LastName = "Marine",
                UserName = "hm",
                NormalizedUserName = "hm".ToUpper(),
                Email = "hm@email.com",
                NormalizedEmail = "hm@email.com".ToUpper(),
                IsAdmin = true,
            };

            u3.PasswordHash = _userManager.PasswordHasher.HashPassword(u3, "12345");
            u3.SecurityStamp = _userManager.CreateSecurityTokenAsync(u3).ToString();

            db.Users.Add(u3);

            db.SaveChanges();
        }

        protected void AddUsers()
        {
            db.Users.Add(new ApplicationUser
            {
                FirstName = "Jackie",
                LastName = "Chan",
                UserName = "jc",
                NormalizedUserName = "jc".ToUpper(),
                NormalizedEmail = "jackie@email.com".ToUpper(),
                PasswordHash = BC.HashPassword("12345"),
                Email = "jackie@email.com",
                IsAdmin = true
            });

            db.Users.Add(new ApplicationUser
            {
                FirstName = "Chun Sing",
                LastName = "Chan",
                UserName = "ccs",
                NormalizedUserName = "ccs".ToUpper(),
                NormalizedEmail = "ccs@email.com".ToUpper(),
                PasswordHash = BC.HashPassword("12345"),
                Email = "ccs@email.com",
                IsAdmin = true
            });

            db.SaveChanges();
            ApplicationUser user = db.Users.FirstOrDefault(user => user.NormalizedUserName.Equals("JC"));

            List<RecipeIngredient> recipeIngredient = new List<RecipeIngredient>();


            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "flaxseeds",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "hempseed",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "banana",
                Quantity = 1,
                UnitOfMeasurement = "banana"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "fresh orange juice",
                Quantity = 2,
                UnitOfMeasurement = "cups"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "sunwarrior protien powder",
                Quantity = 1,
                UnitOfMeasurement = "scoop"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "frozen cranberries",
                Quantity = .5,
                UnitOfMeasurement = "cup"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "bee pollen",
                Quantity = 1,
                UnitOfMeasurement = "tsp"
            });
            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "honey",
                Quantity = 2,
                UnitOfMeasurement = "tbsp"
            });
           
            List<RecipeStep> recipeSteps = new List<RecipeStep>();
            recipeSteps.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "Blend and pour!",
                MediaFileUrl= "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/11/top-view-smoothie-logo.jpg"
            });
           
            List<RecipeTag> recipeTag = new List<RecipeTag>();

            recipeTag.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "smoothie",
                    Warning = ""
                }
            });
            recipeTag.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "orange",
                    Warning = ""
                }
            });
            recipeTag.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "cranberry",
                    Warning = ""
                }
            });


            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "Cranberry Orange Smoothie",
                Description = "Healthy and energtic",
                DateCreated = new DateTime(2019, 6, 3, 8, 30, 52),
                DurationInMins = 40,
                Calories = 500,
                IsPublished = true,
                MainMediaUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/11/cranberry-orange-smoothie-with-logo.jpg",
                RecipeIngredients = recipeIngredient,
                RecipeSteps = recipeSteps,
                RecipeTags = recipeTag
            });

            db.SaveChanges();

            List<RecipeIngredient> recipeIngredient1= new List<RecipeIngredient>();


            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "lamb meat",
                Quantity = 200,
                UnitOfMeasurement = "gms"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "onion",
                Quantity = 100,
                UnitOfMeasurement = "gms"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "tomato",
                Quantity = 100,
                UnitOfMeasurement = "gms"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "curry powder",
                Quantity = 2,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "coconut milk",
                Quantity = 1,
                UnitOfMeasurement = "cup"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "chopped coriander",
                Quantity = 1,
                UnitOfMeasurement = "handful"
            });

           

            List<RecipeStep> recipeSteps1 = new List<RecipeStep>();
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "pour oil add whole garam masala",
                MediaFileUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Slow-Cooked-Lamb-Curry-Progress-Pictures-1.jpg"
            });
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "saute onion and tomato till it turns soft",
                MediaFileUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Slow-Cooked-Lamb-Curry-Recipe-Indian2-2.jpg"
            });
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "add in meat adjust salt and add curry powder",
                MediaFileUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Slow-Cooked-Lamb-Curry-Progress-Pictures-2.jpg"
            });
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "cook till the meat is soft and tender and then add coconut milk cook for 5 mins and add coriander",
                MediaFileUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Slow-Cooked-Lamb-Curry-Progress-Pictures-5.jpg"
            });

            List<RecipeTag> recipeTag1 = new List<RecipeTag>();

            recipeTag1.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "curry",
                    Warning = ""
                }
            });
            recipeTag1.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "lamb",
                    Warning = ""
                }
            });
            recipeTag1.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Indian spicies",
                    Warning = ""
                }
            });


            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "Lamb Curry",
                Description = "Spicy Indian curry",
                DateCreated = new DateTime(2020, 9, 9, 8, 30, 52),
                DurationInMins = 60,
                Calories = 500,
                IsPublished = true,
                MainMediaUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Slow-Cooked-Lamb-Curry-Recipe-Indian14.jpg",
                RecipeIngredients = recipeIngredient1,
                RecipeSteps = recipeSteps1,
                RecipeTags = recipeTag1
            });

            db.SaveChanges();

        }

        protected void AddTags()
        {
            string currentDir = Directory.GetCurrentDirectory();

            using (var reader = new StreamReader(Path.Combine(currentDir, "Db", "FoodData.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');

                    db.Tags.Add(new Tag
                    {
                        TagName = data[3],
                        Warning = data[4]
                    });
                }
            }

            db.SaveChanges();
        }

        protected void AddRecipes()
        {
            db.Users.Add(new ApplicationUser
            {
                FirstName = "Wilson",
                LastName = "Chan",
                UserName = "wc",
                NormalizedUserName = "wc".ToUpper(),
                PasswordHash = BC.HashPassword("12345"),
                Email = "wilson@email.com",
                NormalizedEmail = "wilson@email.com".ToUpper(),
                IsAdmin = true
            });

            db.SaveChanges();

            ApplicationUser user = db.Users.FirstOrDefault();

            List<RecipeIngredient> recipeIngredient = new List<RecipeIngredient>();

            //Please uncomment the following 2 ingredients after testing is over

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "Chocolate",
                Quantity = 100,
                UnitOfMeasurement = "grams"
            });
            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "Milk",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            //To test the generate allergen tags API connection; remove later. 
            //Also, please change the ingredient string limit back to 20 from 100 after testing is over. 
            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "4 large eggs, room temperature",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "2 cups sugar",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "1 teaspoon vanilla extract",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "2-1/4 cups all purpose flour",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "2-1/4 teaspoons baking powder",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "1-1/4 cups 2% milk",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            recipeIngredient.Add(new RecipeIngredient
            {
                Ingredient = "10 tablespoons butter, cubed",
                Quantity = 100,
                UnitOfMeasurement = "ml"
            });

            List<RecipeStep> recipeSteps = new List<RecipeStep>();
            recipeSteps.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "mix chocolate with milk",
                MediaFileUrl = "https://www.wikihow.com/images/thumb/f/ff/Make-a-Simple-Chocolate-Cake-Step-3-Version-3.jpg/aid1334248-v4-728px-Make-a-Simple-Chocolate-Cake-Step-3-Version-3.jpg"
            });
            recipeSteps.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "put in oven",
                MediaFileUrl = "https://www.deliciousmagazine.co.uk/wp-content/uploads/2018/09/321197-1-eng-GB_4469.jpg"
            });

            List<RecipeTag> recipeTag = new List<RecipeTag>();
            recipeTag.Add(new RecipeTag 
            { 
                IsAllergenTag = true, 
                Tag = new Tag 
                { 
                    TagName = "Milk", 
                    Warning = "Lactose Intolerence" 
                } 
            });
            recipeTag.Add(new RecipeTag 
            { 
                IsAllergenTag = false, 
                Tag = new Tag 
                { 
                    TagName = "Cake", 
                    Warning = "" 
                } 
            });
            recipeTag.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Dessert",
                    Warning = ""          
                }
            });

            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "Chocolate Cake",
                Description = "Sweets and Tasty chocolate cake",
                DateCreated = new DateTime(2008, 5, 1, 8, 30, 52),
                DurationInMins = 60,
                Calories = 500,
                IsPublished = true,
                MainMediaUrl = "https://th.bing.com/th/id/OIP.P70fg98tIgi-8b-pMMhZXAHaFj?pid=Api&rs=1",
                RecipeIngredients = recipeIngredient,
                RecipeSteps = recipeSteps,
                RecipeTags= recipeTag
            });

            db.SaveChanges();

            db.Users.Add(new ApplicationUser
            {
                FirstName = "Isabel",
                LastName = "Hui Min",
                UserName = "isabe",
                NormalizedUserName = "isabe".ToUpper(),
                PasswordHash = BC.HashPassword("12345"),
                Email = "isabel@email.com",
                NormalizedEmail = "isabel@email.com".ToUpper(),
                IsAdmin = true
            });

            db.SaveChanges();

            ApplicationUser user1 = db.Users.FirstOrDefault(r => r.UserName == "isabe");

            List<RecipeIngredient> recipeIngredient1 = new List<RecipeIngredient>();

           
            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "5 dried figs (about a 1/4 cup)",
                Quantity = 100,
                UnitOfMeasurement = "gms"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "1/3 cup maple sugar or coconut sugar",
                Quantity = 150,
                UnitOfMeasurement = "gms"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = " crystallized dried ginger ",
                Quantity = 1,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = " chopped pecans",
                Quantity = 100,
                UnitOfMeasurement = "gms"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "salt, nutmeg each",
                Quantity = .25,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "cinnamon, lemon zest",
                Quantity = .5,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredient1.Add(new RecipeIngredient
            {
                Ingredient = "lemon juice",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            List<RecipeStep> recipeSteps1 = new List<RecipeStep>();
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "Mix the stuffing ingredients together",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/10/how-to-stuff-an-apple-1024x756.jpg"
            });
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "Remove the core and stuff the apples ",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/10/how-to-stuff-an-apple-1024x756.jpg"
            });
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "Squeeze the rest of the lemon on top of the apples Put the water in the slow cooker(if a little gets on the apples, that's alright)",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/10/crockpot-apples-244x300.jpg"
            });
            recipeSteps1.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "Put the apples in a slow cooker for 1.5 hours on high",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/10/eating-apple-768x1024.jpg"
            });

            List<RecipeTag> recipeTag1 = new List<RecipeTag>();
            
            recipeTag1.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Dessert",
                    Warning = ""
                }
            });
            recipeTag1.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Apple",
                    Warning = ""
                }
            });
            recipeTag1.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "fig",
                    Warning = ""
                }
            });

            db.Recipes.Add(new Recipe
            {
                UserId = user1.Id,
                Title = "Stuffed Apples with Figs",
                Description = "These are drool-worthy!",
                DateCreated = new DateTime(2013, 6, 3, 8, 30, 52),
                DurationInMins = 65,
                Calories = 500,
                IsPublished = true,
                MainMediaUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/10/stuffed-apples.jpg",
                RecipeIngredients = recipeIngredient1,
                RecipeSteps = recipeSteps1,
                RecipeTags = recipeTag1
            });

            db.SaveChanges();

            List<RecipeIngredient> recipeIngredient2 = new List<RecipeIngredient>();


            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "avocado oil",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });

            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "medium yellow onion (chopped)",
                Quantity = 1,
                UnitOfMeasurement = "onion"
            });

            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = " leeks (chopped)  ",
                Quantity = 1,
                UnitOfMeasurement = "leeks"
            });

            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "garlic cloves (chopped) ",
                Quantity = 2,
                UnitOfMeasurement = "cloves"
            });

            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "peeled potatoes",
                Quantity = 5,
                UnitOfMeasurement = "lbs"
            });

            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "fresh thyme, dries parsley",
                Quantity = 1,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "almond milk",
                Quantity = 2,
                UnitOfMeasurement = "cups"
            });
            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "vegetable broth",
                Quantity = 6,
                UnitOfMeasurement = "cups"
            });
            recipeIngredient2.Add(new RecipeIngredient
            {
                Ingredient = "cognac",
                Quantity = 2,
                UnitOfMeasurement = "tbsp"
            });

            List<RecipeStep> recipeSteps2 = new List<RecipeStep>();
            recipeSteps2.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "Make a rue with the first 4 ingredients by combining in a stockpot and sweat the vegetables until golden brown.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/03/leeks-rue-600x397.jpg"
            });
            recipeSteps2.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "Add the rest of the ingredients to the pot and boil. Once boiling (about 10 minutes), reduce to a simmer until the potatoes are tender. Around another 20 minutes. ",
               
            });
            recipeSteps2.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "Remove the bay leaves, then use an immersion blender and blend to desired consistency.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/03/vegan-simple-potato-leek-soup-678x1024.jpg"
            });
            recipeSteps2.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "Stir and taste test! This is where you decide if it needs more salt, cognac, almond milk, etc., based on your taste buds and the texture you like. (Don’t fill the blender more than 3/4 of the way)",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/03/creamy-potato-leek-soup-1024x678.jpg"
            });

            List<RecipeTag> recipeTag2 = new List<RecipeTag>();

            recipeTag2.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Soup",
                    Warning = ""
                }
            });
            recipeTag2.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "creamy",
                    Warning = ""
                }
            });
            recipeTag2.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Leek",
                    Warning = ""
                }
            });

            db.Recipes.Add(new Recipe
            {
                UserId = user1.Id,
                Title = "SIMPLE CREAMY POTATO LEEK SOUP (VEGAN)",
                Description = "simple and tasty!",
                DateCreated = new DateTime(2013, 6, 3, 8, 30, 52),
                DurationInMins = 35,
                Calories = 500,
                IsPublished = true,
                MainMediaUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2015/03/simple-potato-leek-soup-vegan-1024x672.jpg",
                RecipeIngredients = recipeIngredient2,
                RecipeSteps = recipeSteps2,
                RecipeTags = recipeTag2
            });

            db.SaveChanges();

            List<RecipeIngredient> recipeIngredientsquid = new List<RecipeIngredient>();


            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "Squid",
                Quantity = 2,
                UnitOfMeasurement = "squid"
            });

            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "salt,sugar,pepper",
                Quantity = .25,
                UnitOfMeasurement = "tsp"
            });

            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = " leek ",
                Quantity = 15,
                UnitOfMeasurement = "gms"
            });

            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "red capsicum and celery each ",
                Quantity = 30,
                UnitOfMeasurement = "gms"
            });

            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "garlic",
                Quantity = 1,
                UnitOfMeasurement = "clove"
            });

            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "red chilly",
                Quantity = 8,
                UnitOfMeasurement = "whole"
            });

            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "oyster sauce, Worcestershire sauce,light soy sauce,black vinegar",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });
            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "chicken stock granules",
                Quantity = .5,
                UnitOfMeasurement = "tsp"
            });
            recipeIngredientsquid.Add(new RecipeIngredient
            {
                Ingredient = "chicke stock",
                Quantity = 125,
                UnitOfMeasurement = "ml"
            });

            List<RecipeStep> recipeStepssquid = new List<RecipeStep>();
            recipeStepssquid.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "Skin the squid and score the inner part to form criss-cross pattern. Season with salt, sugar and pepper.",
                MediaFileUrl = "https://c8.alamy.com/comp/2AN63CK/raw-squid-on-ice-with-salad-spices-lemon-garlic-on-white-plate-background-fresh-squids-octopus-or-cuttlefish-for-cooked-food-at-restaurant-or-seafoo-2AN63CK.jpg"
            });
            recipeStepssquid.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "In a wok or large enough saucepan, bring water to boil and scald the squid for just a few seconds. Remove and drain well. Cut into bite sizes.",
                MediaFileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Q6hrXXQZ5ISNAu4UfqGDcdJQwYvwzXtgZQ&usqp=CAU"
            });
            recipeStepssquid.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "In a wok, heat the sesame oil and fry the garlic until lightly coloured. Add ginger and dried chillies, and fry until aromatic. Add the celery, leek and capsicum. Toss and fry briefly for 10 to 20 seconds.",
               
            });
            recipeStepssquid.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "Stir in the sauce ingredients and bring to a quick boil. Once the sauce thickens, return squid to the wok and stir-fry over high heat for a few seconds. Dish out and serve.",
                MediaFileUrl = "https://img-global.cpcdn.com/recipes/7377ab64d09dfcb2/751x532cq70/spicy-squid-masala-fry-recipe-main-photo.jpg"
            });

            List<RecipeTag> recipeTagsquid = new List<RecipeTag>();

            recipeTagsquid.Add(new RecipeTag
            {
                IsAllergenTag = true,
                Tag = new Tag
                {
                    TagName = "seafood",
                    Warning = "SeaFood Allergy"
                }
            });
            recipeTagsquid.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "spicy",
                    Warning = ""
                }
            });
            recipeTagsquid.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "squid",
                    Warning = ""
                }
            });
            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "Mala Squid",
                Description = "Hot and spicy",
                DateCreated = new DateTime(2010, 10, 1, 8, 30, 52),
                DurationInMins = 30,
                Calories = 600,
                IsPublished = true,
                MainMediaUrl = "https://singaporebeauty.com/wp-content/uploads/2017/10/dm-chicken-squid-close-up.jpg",
                RecipeIngredients = recipeIngredientsquid,
                RecipeSteps = recipeStepssquid,
                RecipeTags = recipeTagsquid
            });

            db.SaveChanges();

            List<RecipeIngredient> recipeIngredientsushi = new List<RecipeIngredient>();


            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = " Nori (seaweed or soy paper)",
                Quantity = 4,
                UnitOfMeasurement = "full sheet"
            });

            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "peeled sweet potatoes",
                Quantity = 3,
                UnitOfMeasurement = "whole"
            });

            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "asparagus (cut to match the length of Nori sheet)",
                Quantity = 1,
                UnitOfMeasurement = "cup"
            });

            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "olive tapenade",
                Quantity = 1,
                UnitOfMeasurement = "cup"
            });

            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "apple cider vinegar (or rice vinegar)",
                Quantity = .25,
                UnitOfMeasurement = "cup"
            });

            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "chives, pea shoots",
                Quantity = .5,
                UnitOfMeasurement = "cup"
            });

            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "cucumber, carrot, avocado",
                Quantity = 1,
                UnitOfMeasurement = "sliced"
            });
            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "ginger, cilantro (mince)",
                Quantity = 1,
                UnitOfMeasurement = "tbsp"
            });
            recipeIngredientsushi.Add(new RecipeIngredient
            {
                Ingredient = "cashew",
                Quantity = 1,
                UnitOfMeasurement = "cups"
            });

            List<RecipeStep> recipeStepssushi = new List<RecipeStep>();
            recipeStepssushi.Add(new RecipeStep
            {
                StepNumber = 1,
                TextInstructions = "Layout a sheet of Nori on a cutting board and spread a thin layer of pureed sweet potatoes slowly over the Nori with a spoon",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/09/beginning-prep.jpg"
            });
            recipeStepssushi.Add(new RecipeStep
            {
                StepNumber = 2,
                TextInstructions = "Put filling ingredients in the center of the roll",
                MediaFileUrl= "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/09/prep.jpg"
            });
            recipeStepssushi.Add(new RecipeStep
            {
                StepNumber = 3,
                TextInstructions = "Feel free to add the rice as part of the sweet potato if you prefer, like this.",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/09/Final-Filling.jpg"
            });
            recipeStepssushi.Add(new RecipeStep
            {
                StepNumber = 4,
                TextInstructions = "Dampen fingers with apple cider vinegar and roll tight " +
                                    "Seal sides with apple cider vinegar"+
                                     "Slice slowly with a serrated knife",
                MediaFileUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/09/Cutting-Sushi.jpg"
            });

            List<RecipeTag> recipeTagsushi = new List<RecipeTag>();

            recipeTagsushi.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Sushi",
                    Warning = ""
                }
            });
            recipeTagsushi.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Nori",
                    Warning = ""
                }
            });
            recipeTagsushi.Add(new RecipeTag
            {
                IsAllergenTag = false,
                Tag = new Tag
                {
                    TagName = "Vegan",
                    Warning = ""
                }
            });
            db.Recipes.Add(new Recipe
            {
                UserId = user.Id,
                Title = "SWEET POTATO VEGAN SUSHI ROLLS",
                Description = "the sweet, almost chewy texture that it adds",
                DateCreated = new DateTime(2017, 10, 1, 8, 30, 52),
                DurationInMins = 60,
                Calories = 496,
                IsPublished = true,
                MainMediaUrl = "https://foodscape.vanillaplummedia.com/wp-content/uploads/2014/09/vegan-sweet-potato-sushi-1024x1024.jpg",
                RecipeIngredients = recipeIngredientsushi,
                RecipeSteps = recipeStepssushi,
                RecipeTags = recipeTagsushi
            });

            db.SaveChanges();









        }

        protected void AddGroups()
        {
            db.Users.Add(new ApplicationUser
            {
                FirstName = "Tingkai",
                LastName = "Chua",
                UserName = "ctk",
                NormalizedEmail = "ctk@email.com".ToUpper(),
                NormalizedUserName = "ctk".ToUpper(),
                PasswordHash = BC.HashPassword("12345"),
                Email = "ctk@email.com",
                IsAdmin = true
            });

            db.SaveChanges();

            List<GroupTag> groupTag = new List<GroupTag>();
            groupTag.Add(new GroupTag
            {
                Tag = new Tag
                {
                    TagName = "noodles",
                    Warning = "noodles"
                }
            });
            groupTag.Add(new GroupTag
            {
                Tag = new Tag
                {
                    TagName = "rice",
                    Warning = "rice"
                }
            });
            groupTag.Add(new GroupTag
            {
                Tag = new Tag
                {
                    TagName = "meat",
                    Warning = "meat"
                }
            });
            groupTag.Add(new GroupTag
            {
                Tag = new Tag
                {
                    TagName = "vegan",
                    Warning = "vegan"
                }
            });

           

            db.SaveChanges();

            db.Groups.Add(new Group
            {
                GroupName = "Cake Lover",
                GroupPhoto = "https://scontent.fsin2-1.fna.fbcdn.net/v/t1.0-9/41755292_838712536518336_4483106259637108736_n.jpg?_nc_cat=110&ccb=3&_nc_sid=09cbfe&_nc_ohc=wb4KQInKMPwAX-HZrmX&_nc_ht=scontent.fsin2-1.fna&oh=b32f73526238c83ba946405b53e2a74d&oe=6050FC74",
                Description = "Cakes make me Happy",
                DateCreated = new DateTime(2018, 5, 1, 8, 30, 52),
                IsPublished = true,
                GroupTags = groupTag
            });

            

            db.SaveChanges();

            db.Groups.Add(new Group
            {
                GroupName = "No Ramen No Life",
                GroupPhoto = "https://www.justonecookbook.com/wp-content/uploads/2017/07/Spicy-Shoyu-Ramen-NEW-500x400.jpg",
                Description = "Shoyu, Tonkotsu and Shio is our holy trinity",
                DateCreated = new DateTime(2008, 5, 15, 8, 30, 52),
                IsPublished = true,
                GroupTags = groupTag
            });

            db.Groups.Add(new Group
            {
                GroupName = "Curry and Spices",
                GroupPhoto = "https://d3e8d6e8.rocketcdn.me/wp-content/uploads/2018/11/South-Indian-Chicken-Curry-3-of-5.jpg",
                Description = "Let the aroma soak up our senses",
                DateCreated = new DateTime(2010, 5, 15, 8, 30, 52),
                IsPublished = true,
                GroupTags = groupTag
            });

            db.Groups.Add(new Group
            {
                GroupName = "Korean Cuisine",
                GroupPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRss_o33i1x0K_OzS6IqnF4G4tFkzWwVmGgBg&usqp=CAU",
                Description = "Oppa Saranghae",
                DateCreated = new DateTime(2012, 5, 15, 8, 30, 52),
                IsPublished = true,
                GroupTags = groupTag
            });

            db.SaveChanges();

            ApplicationUser user = db.Users.FirstOrDefault();
            Group group = db.Groups.FirstOrDefault();
            Group group2 = db.Groups.Where(x => x.GroupId == 2).FirstOrDefault();

            db.UsersGroups.Add(new UsersGroup
            {
                GroupId = group.GroupId,
                UserId = user.UserId,
                IsMod = true
            });

            db.UsersGroups.Add(new UsersGroup
            {
                GroupId = group2.GroupId,
                UserId = user.UserId,
                IsMod = true
            });

            db.UsersGroups.Add(new UsersGroup
            {
                GroupId = 3,
                UserId = user.UserId,
                IsMod = true
            });

            db.SaveChanges();

            db.RecipeGroups.Add(new RecipeGroup
            {
                GroupId = 3,
                RecipeId = 1
            });

            db.RecipeGroups.Add(new RecipeGroup
            {
                GroupId = 4,
                RecipeId = 2
            });

            db.SaveChanges();


        }
    }
}
