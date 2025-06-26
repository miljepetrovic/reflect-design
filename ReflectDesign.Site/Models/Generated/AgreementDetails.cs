using ReflectDesign.Site.Extensions;

namespace ReflectDesign.Site.Models.Generated;

public partial class AgreementDetails : IBlock
{
    public IReadOnlyList<AgreementStep> CastedSteps
        => Steps.GetBlockListItems<AgreementStep>();
}
