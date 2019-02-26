using Musi_Tech_.Data;
using Musi_Tech_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Services
{
    public class LessonService
    {
        private readonly Guid _userId;

        public LessonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLesson(LessonCreate model)
        {
            var entity =
                new Lesson()
                {
                    OwnerId = _userId,
                    Instrument = model.Instrument,
                    CustomerId = model.CustomerId,
                    Date = model.Date,
                    Cost = model.Cost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Lessons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LessonListItem> GetLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Lessons
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LessonListItem
                                {
                                    LessonId = e.LessonId,
                                    Instrument = e.Instrument,
                                    Date = e.Date,
                                    Cost = e.Cost
                                }
                        );

                return query.ToArray();
            }
        }

        public LessonDetail GetLessonById(int lessonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == lessonId && e.OwnerId == _userId);
                return
                    new LessonDetail
                    {
                        LessonID = entity.LessonId,
                        Instrument = entity.Instrument,
                        CustomerID = entity.CustomerId,
                        Date =  entity.Date,
                        Cost = entity.Cost
                    };
            }
        }

        public bool UpdateLesson(LessonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == model.LessonId && e.OwnerId == _userId);

                entity.Instrument = model.Instrument;
                entity.CustomerId = model.CustomerId;
                entity.Date = model.Date;
                entity.Cost = model.Cost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLesson(int lessonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == lessonId && e.OwnerId == _userId);

                ctx.Lessons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }    
}
