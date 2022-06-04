using Test.DBContext;

Console.WriteLine("Hello, World!");

var context = new demoContext();

var working = context.Blogs.Where(x => x.CreatedDate == DateTime.Today).ToList();
var working2 = context.Blogs.Where(x => x.CreatedDate.Date > DateTime.Today).ToList();
var working3 = context.Blogs.Where(x => x.CreatedDate.Date < DateTime.Today).ToList();

var notWorking = context.Blogs.Where(x => x.CreatedDate.Date == DateTime.Today).ToList();

Console.WriteLine("END");
