
namespace Models
{
    class RegExp
    { 
        Operator op;
        public enum Operator { PLUS, STAR, OR, DOT, ONE };

        static Comparator<String> compareByLength 
        = new Comparator<String> ()
            {
                public int compare(string s1, string s2)
                {
                if (s1.Length == s2.Length)
                    {return s1.CompareTo(s2);}
                else
                    {return s1.Length - s2.Length;}
                }
            };
            
    public RegExp()
    {
        op = Operator.ONE;
        terminals = "";
        left = null;
        right = null;
    }
    
    public RegExp(String p)
    {
        op = Operator.ONE;
        terminals = p;
        left = null;
        right = null;
    }
    
    public RegExp plus()
    {
        RegExp result = new RegExp();
        result.op = Operator.PLUS;
        result.left = this;
        return result;
    }

    public RegExp star()
    {
        RegExp result = new RegExp();
        result.op = Operator.STAR;
        result.left = this;
        return result;
    }

    public RegExp or(RegExp e2)
    {
        RegExp result = new RegExp();
        result.op = Operator.OR;
        result.left = this;
        result.right = e2;
        return result;
    }

    public RegExp dot(RegExp e2)
    {
        RegExp result = new RegExp();
        result.op = Operator.DOT;
        result.left = this;
        result.right = e2;
        return result;
    }

    public SortedSet <String>  getLanguage(int maxSteps)
    {
        SortedSet<String> emptyLanguage = new TreeSet<String>(compareByLength);
        SortedSet<String> languageResult = new TreeSet<String>(compareByLength);
        
        SortedSet<String> languageLeft, languageRight;
        
        if (maxSteps < 1) return emptyLanguage;
        
        switch (this.op) {
            case ONE:
                 {languageResult.add(terminals);}

            case OR:
                languageLeft = left == null ? emptyLanguage : left.getLanguage(maxSteps - 1);
                languageRight = right == null ? emptyLanguage : right.getLanguage(maxSteps - 1);
                languageResult.addAll (languageLeft);
                languageResult.addAll (languageRight);
                break;
                

            case DOT:
                languageLeft = left == null ? emptyLanguage : left.getLanguage(maxSteps - 1);
                languageRight = right == null ? emptyLanguage : right.getLanguage(maxSteps - 1);
                for (String s1 : languageLeft)
                    for (String s2 : languageRight)
                       {languageResult.add (s1 + s2);}
                break;

            // STAR(*) en PLUS(+) kunnen we bijna op dezelfde manier uitwerken:
            case STAR:
            case PLUS:
                languageLeft = left == null ? emptyLanguage : left.getLanguage(maxSteps - 1);
                languageResult.addAll(languageLeft);
                for (int i = 1; i < maxSteps; i++)
                {   HashSet<String> languageTemp = new HashSet<String>(languageResult);
                    for (String s1 : languageLeft)
                    {   for (String s2 : languageTemp)
                        {   languageResult.add (s1+s2);
                        }
                    }
                }
                if (this.op  == Operator.STAR)
                    {languageResult.add("");}
                break;

                
            default:
                System.out.println ("getLanguage is nog niet gedefinieerd voor de operator: " + this.operator);
                break;
        }        
                
            
        return languageResult;
    }  
    }
}
