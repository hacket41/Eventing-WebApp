using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Eventing.Web.Components.Features.Register.Models;
using Eventing.Web.Components.Features.Register.Dtos;

namespace Eventing.Web.Components.Features.Register
{
    public partial class Register : ComponentBase
    {
        [Inject] private HttpClient Http { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;

        public RegisterModel RegisterModel { get; set; } = new();
        private string ErrorMessage { get; set; } = string.Empty;

        private async Task SubmitAsync()
        {
            ErrorMessage = string.Empty;

            if (!RegisterModel.AgreeTerms)
            {
                ErrorMessage = "You must agree to the terms and conditions.";
                return;
            }

            try
            {
                var dto = new RegisterRequestDto
                {
                    Name = RegisterModel.FullName,
                    Email = RegisterModel.Email,
                    Password = RegisterModel.Password,
                    ConfirmPassword = RegisterModel.ConfirmPassword
                };

                var response = await Http.PostAsJsonAsync("api/account/register", dto);

                if (response.IsSuccessStatusCode)
                {
                    // Navigate to login page after successful registration
                    NavManager.NavigateTo("/login");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ErrorMessage = $"Registration failed: {error}";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Something went wrong: {ex.Message}";
            }
        }
    }
}