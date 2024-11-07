﻿using Microsoft.EntityFrameworkCore;
using RackManager.Data;
using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Services.SnakeProviders
{
    public class SnakeProvider : ISnakeProvider
    {
        private readonly IDbContextFactory _dbContextFactory;

        public SnakeProvider(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<SnakeModel>> RetrieveAllSnakes()
        {
            using (ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SnakeDTO> snakeDTOs = await dbContext.Snakes
                    .Include(item => item.Temp)
                    .Include(item => item.Humidity)
                    .Include(item => item.Enclousure)
                    .ToListAsync();

                return snakeDTOs.Select(snake => ToSnakeModel(snake));
            }
        }
        public SnakeModel ToSnakeModel(SnakeDTO snake)
        {
            return new SnakeModel(
                                    snake.Image,
                                    false,
                                    snake.Name,
                                    snake.DateOfBirth,
                                    snake.Weight,
                                    snake.Sex,
                                    snake.Subspecies,
                                    snake.IsVenomous,
                                    snake.LastFeedingDate,
                                    snake.WaterReplacementDate,
                                    snake.Length,
                                    new TempModel(
                                        snake.Temp.MinValue,
                                        snake.Temp.MaxValue
                                        ),
                                    new HumidityModel(
                                        snake.Humidity.MinValue,
                                        snake.Humidity.MaxValue
                                        ),
                                    new EnclousureModel(
                                        snake.Enclousure.Width,
                                        snake.Enclousure.Height,
                                        snake.Enclousure.Length
                                        )
                                    );
        }
    }
}
