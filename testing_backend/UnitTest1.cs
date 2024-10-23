using demo_part2;

namespace testing_backend
{
    public class UnitTest1
    {
        //object name from the class
        testing_login_register_claim  test_all = new testing_login_register_claim();

        [Fact]
        public void Login_correct()
        {

            //what to expect
            string expected = "user found";
            //results
            string result = test_all.Login("rose@gmail.com","12345");

            //then out come
            Assert.Equal(expected, result);

        }
    }
}