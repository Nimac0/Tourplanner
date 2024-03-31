using tour_planner.DTOs;
using tour_planner.ViewModels;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_ConvertInputToTour_Given_valid_input()
        {
            // Arrange
            var fakeUserInput = new TourInfoInput
            {
                Tourname = "Test Tour",
                Description = "This is a test tour",
                Transportation = "Bicycle",
                From = "Start Location",
                To = "End Location"
            };
            var fakeUsercontrol = new TourInputViewModel();

            // Act
            var fakeTourInfo = fakeUsercontrol.ConvertInputToTour(fakeUserInput);

            // Assert
            Assert.That(fakeTourInfo.Name, Is.EqualTo(fakeUserInput.Tourname));
            Assert.That(fakeTourInfo.Description, Is.EqualTo(fakeUserInput.Description));
            Assert.That(fakeTourInfo.ModeOfTransportation, Is.EqualTo(fakeUserInput.Transportation));
            Assert.That(fakeTourInfo.RouteInfo.From, Is.EqualTo(fakeUserInput.From));
            Assert.That(fakeTourInfo.RouteInfo.To, Is.EqualTo(fakeUserInput.To));
            Assert.That(fakeTourInfo.Tourlogs, Is.EqualTo(new List<TourLog>()));
            Assert.That(fakeTourInfo.RouteInfo.Distance, Is.EqualTo(""));
            Assert.That(fakeTourInfo.RouteInfo.EstimateTime, Is.EqualTo(""));
            Assert.That(fakeTourInfo.RouteInfo.PictureFilePath, Is.EqualTo(""));
        }
        [Test]
        public void Test_ClearInputFields_ClearsAllFields()
        {
            //Arrange
            var fakeInstance = new TourInputViewModel();
            fakeInstance.TourUserInput = new TourInfoInput
            {
                Tourname = "Test Tour",
                Description = "This is a test tour",
                Transportation = "Bicycle",
                From = "Start Location",
                To = "End Location"
            };

            // Act
            fakeInstance.ClearInputFields();

            // Assert
            Assert.That(fakeInstance.TourUserInput.Tourname, Is.Empty);
            Assert.That(fakeInstance.TourUserInput.Description, Is.Empty);
            Assert.That(fakeInstance.TourUserInput.Transportation, Is.Empty);
            Assert.That(fakeInstance.TourUserInput.From, Is.Empty);
            Assert.That(fakeInstance.TourUserInput.To, Is.Empty);
        }

        [Test]
        public void Test_IsAnyNullOrEmpty_Given_Empty_Field()
        {
            //Arrange
            var fakeInstance = new TourInputViewModel();
            fakeInstance.TourUserInput = new TourInfoInput
            {
                Tourname = "",
                Description = "",
                Transportation = "Bicycle",
                From = "Start Location",
                To = "End Location"
            };

            //Act
            var result = fakeInstance.IsAnyNullOrEmpty(fakeInstance.TourUserInput);
            //Assert
            Assert.That(result == true);
        }

        [Test]
        public void Test_IsAnyNullOrEmpty_Given_Valid_Input()
        {
            //Arrange
            var fakeInstance = new TourInputViewModel();
            fakeInstance.TourUserInput = new TourInfoInput
            {
                Tourname = "Test Tour",
                Description = "This is a test tour",
                Transportation = "Bicycle",
                From = "Start Location",
                To = "End Location"
            };

            //Act
            var result = fakeInstance.IsAnyNullOrEmpty(fakeInstance.TourUserInput);
            //Assert
            Assert.That(result == false);
        }
    }
}