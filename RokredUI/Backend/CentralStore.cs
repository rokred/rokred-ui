using System;
namespace RokredUI.Backend
{
    public static class CentralStore
    {
        public static OpinionModel BrandNewOpinion { get; private set; }
        public static bool IsCreatingNewOpinion => BrandNewOpinion != null;

        public static void StartCreatingNewOpinion()
        {
            BrandNewOpinion = new OpinionModel();
        }
    }
}
