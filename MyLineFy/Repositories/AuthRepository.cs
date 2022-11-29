using Blazored.LocalStorage;
using Spotboard.Data;
using Spotboard.Interfaces;

namespace Spotboard.Repositories
{
    public class AuthRepository : IRepository<AuthorizationResponse>
    {
        private readonly ILocalStorageService _storageService;
        private const string _key = "auth";

        public AuthRepository(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }
        public async Task SaveAsync(AuthorizationResponse model)
        {
            await _storageService.SetItemAsync<AuthorizationResponse>(_key, model);
        }

        public async Task<AuthorizationResponse> GetAsync()
        {
            return await _storageService.GetItemAsync<AuthorizationResponse>(_key);
        }

    }
}
